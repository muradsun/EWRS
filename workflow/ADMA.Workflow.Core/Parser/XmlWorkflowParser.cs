using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ADMA.Common;
using ADMA.Workflow.Core.Model;
using ADMA.Workflow.Core.Fault;

namespace ADMA.Workflow.Core.Parser
{
    public class XmlWorkflowParser :  WorkflowParser<XElement>
    {
        public override List<TimerDefinition> ParseTimers(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var timersElement = schemeMedium.SingleOrDefault("Timers");

            if (timersElement == null) return new List<TimerDefinition>();

            return timersElement.Elements().ToList().Select(element => TimerDefinition.Create(GetName(element), GetType(element), GetDelay(element), GetInterval(element))).ToList();
        }

        public override List<ActorDefinition> ParseActors(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var actorsElement = schemeMedium.SingleOrDefault("Actors");

            if (actorsElement == null) return new List<ActorDefinition>();

            var actors = new List<ActorDefinition>();

            foreach (var element in actorsElement.Elements().ToList())
            {
                ActorDefinition actor = null;
                if (element.Element("IsIdentity") !=  null)
                {
                    actor = ActorDefinition.CreateIsIdentity(GetName(element), GetId(element.Element("IsIdentity")));
                }
                else if (element.Element("Rule") != null)
                {
                    actor = ActorDefinition.CreateRule(GetName(element), GetRuleName(element.Element("Rule")));
                    var parameters = element.Element("Rule").Elements("RuleParameter");
                    foreach (var parameter in parameters)
                    {
                        actor.AddParameter(GetName(parameter),GetValue(parameter));
                    }
                }
                else if (element.Element("IsInRole") != null)
                {
                    actor = ActorDefinition.CreateIsInRole(GetName(element), GetId(element.Element("IsInRole")));
                }

                if (actor != null) actors.Add(actor);
            }

            return actors;
        }

        public override List<LocalizeDefinition> ParseLocalization(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var localizationElement = schemeMedium.SingleOrDefault("Localization");

            var localization = new List<LocalizeDefinition>();

            if (localizationElement == null) return localization;

            foreach (var element in localizationElement.Elements().ToList())
            {
                var localizeDefinition =LocalizeDefinition.Create(GetObjectName(element), GetType(element), GetCulture(element),
                                          GetValue(element), GetIsDefault(element));

                
                localization.Add(localizeDefinition);
            }

            return localization;
        }

        public override List<ParameterDefinition> ParseParameters(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            var parametersElement = schemeMedium.SingleOrDefault("Parameters");
            
            var parameters = new List<ParameterDefinition>();

            if (parametersElement != null)
            {
                foreach (var element in parametersElement.Elements().ToList())
                {
                    ParameterDefinition parameterDefinition;
                    if (element.Attributes("Purpose").Count() == 1)
                    {
                        parameterDefinition = ParameterDefinition.Create(GetName(element),
                                                                         element.Attributes("Type").Single().Value,
                                                                         element.Attributes("Purpose").Single().Value, GetDefaultValue(element));
                    }
                    else
                    {
                        parameterDefinition = ParameterDefinition.Create(GetName(element), element.Attributes("Type").Single().Value, GetDefaultValue(element));
                    }

                    parameters.Add(parameterDefinition);

                }
            }

            parameters.AddRange(DefaultDefinitions.DefaultParameters);

            return parameters;
        }

        public override List<CommandDefinition> ParseCommands(XElement schemeMedium, List<ParameterDefinition> parameterDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (parameterDefinitions == null) throw new ArgumentNullException("parameterDefinitions");
            var commandsElement = schemeMedium.SingleOrDefault("Commands");


            var commands = new List<CommandDefinition>();
            if (commandsElement == null) return commands;
            
            var parameterDefinitionsList = parameterDefinitions.ToList();

            

            foreach (var element in commandsElement.Elements().ToList())
            {
                var command = CommandDefinition.Create(GetName(element));
                var el = element.Elements("InputParameters").SingleOrDefault();
                if (el != null)
                {
                    foreach (var xmlInputParameter in el.Elements())
                    {
                        var parameterRef = parameterDefinitionsList.FirstOrDefault(pd => pd.Name == GetNameRef(xmlInputParameter));
                        if (parameterRef == null)
                        {
                            throw new Exception(); //SchemeNotValidException(string.Format("Command {0}: parameter '{1}' not found",command.Name, GetNameRef(xmlInputParameter)));
                        }
                        command.AddParameterRef(GetName(xmlInputParameter), parameterRef);
                    }
                }

                commands.Add(command);
            }

            return commands;
        }

        public override List<ActionDefinition> ParseActions(XElement schemeMedium, List<ParameterDefinition> parameterDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (parameterDefinitions == null) throw new ArgumentNullException("parameterDefinitions");
            var actionElements = schemeMedium.SingleOrDefault("Actions");

            var actions = new List<ActionDefinition>();
            if (actionElements == null) return actions; 
            
            var parameterDefinitionsList = parameterDefinitions.ToList();

            

            foreach (var element in actionElements.Elements().ToList())
            {
                if (element.Elements("ExecuteMethod").Count() > 1)
                {
                    throw new Exception(); // Murad Fix: SchemeNotValidException(string.Format("Action {0}: block may contain only one section ExecuteMethod", element.Name));
                }

                var executeMethodElement = element.Elements("ExecuteMethod").Single();

                var typeName = GetType(executeMethodElement);

                var action = ActionDefinition.Create(GetName(element), typeName, GetMethodName(executeMethodElement));

                //if (action.Type == null)
                //{
                //    throw new SchemeNotValidException(string.Format("Type {0}: not found", typeName));
                //}
                
                var inputParameters = executeMethodElement.Elements("InputParameters").SingleOrDefault();

                if (inputParameters != null)
                    foreach (var xmlInputParameter in inputParameters.Elements())
                    {
                        var parameterRef = parameterDefinitionsList.Single(pd => pd.Name == GetNameRef(xmlInputParameter));
                        var parameterForAction = ParameterDefinition.Create(parameterRef, GetOrder(xmlInputParameter));
                        action.AddInputParameterRef(parameterForAction);
                    }

                var outputParameters = executeMethodElement.Elements("OutputParameters").SingleOrDefault();

                if (outputParameters != null)
                    foreach (var xmlOutputParameter in outputParameters.Elements())
                    {
                        var parameterRef =
                            parameterDefinitionsList.Single(pd => pd.Name == GetNameRef(xmlOutputParameter));
                        var parameterForAction = ParameterDefinition.Create(parameterRef, GetOrder(xmlOutputParameter));
                        action.AddOutputParameterRef(parameterForAction);
                    }

                actions.Add(action);
            }

            return actions;
        }

        public override List<ActivityDefinition> ParseActivities(XElement schemeMedium, List<ActionDefinition> actionDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (actionDefinitions == null) throw new ArgumentNullException("actionDefinitions");
            var activitiesElements = schemeMedium.SingleOrDefault("Activities"); 
            if (activitiesElements == null) throw new ArgumentNullException("");

            var actionDefinitionsList = actionDefinitions.ToList();

            var activities = new List<ActivityDefinition>();

            foreach (var element in activitiesElements.Elements().ToList())
            {
                var activity = ActivityDefinition.Create(GetName(element), GetState(element), GetIsInitial(element),
                                                         GetIsFinal(element), GetIsForSetState(element),GetIsAutoSchemeUpdate(element));


                var implementation = element.Elements("Implementation").ToList();

                if (implementation.Count() > 0)
                    foreach (var xmlOutputParameter in implementation.Single().Elements())
                    {
                        string nameRef = GetNameRef(xmlOutputParameter);
                        ActionDefinition actionRef = actionDefinitionsList.SingleOrDefault(ad => ad.Name == nameRef);
                        if (actionRef == null)
                            throw new KeyNotFoundException(string.Format("Action {0} not found", nameRef));
                        activity.AddAction(ActionDefinition.Create(actionRef, GetOrder(xmlOutputParameter)));
                    }

                var preExecutionImplementation = element.Elements("PreExecutionImplementation").ToList();

                if (preExecutionImplementation.Count() > 0)
                    foreach (var xmlOutputParameter in preExecutionImplementation.Single().Elements())
                    {
                        var actionRef = actionDefinitionsList.Single(ad => ad.Name == GetNameRef(xmlOutputParameter));
                        activity.AddPreExecutionAction(ActionDefinition.Create(actionRef, GetOrder(xmlOutputParameter)));
                    }

                activities.Add(activity);
            }

            return activities;
        }

        public override List<TransitionDefinition> ParseTransitions(XElement schemeMedium, List<ActorDefinition> actorDefinitions, List<CommandDefinition> commandDefinitions, List<ActionDefinition> actionDefinitions, List<ActivityDefinition> activityDefinitions, List<TimerDefinition> timerDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (commandDefinitions == null) throw new ArgumentNullException("commandDefinitions");
            if (actionDefinitions == null) throw new ArgumentNullException("actionDefinitions");
            if (activityDefinitions == null) throw new ArgumentNullException("activityDefinitions");
            var transitionElements = schemeMedium.SingleOrDefault("Transitions");

            var transitions = new List<TransitionDefinition>();
            if (transitionElements == null) return transitions;

            var commandDefinitionsList = commandDefinitions.ToList();
            var actionDefinitionsList = actionDefinitions.ToList();
            var activityDefinitionsList = activityDefinitions.ToList();
            var actorDefinitionsList = actorDefinitions.ToList();
            var timerDefinitionsList = timerDefinitions.ToList();

            

            foreach (var transitionElement in transitionElements.Elements().ToList())
            {
                var fromActivity = activityDefinitionsList.Single(ad => ad.Name == GetFrom(transitionElement));
                var toActivity = activityDefinitionsList.Single(ad => ad.Name == GetTo(transitionElement));
                
                TriggerDefinition trigger = null;
                var triggersElement = transitionElement.Element("Triggers");
                if (triggersElement != null)
                {
                    var triggerElement = triggersElement.Element("Trigger");
                    if (triggerElement != null)
                    {
                        trigger = TriggerDefinition.Create(GetType(triggerElement));

                        var nameRef = GetNameRef(triggerElement);
                        if (nameRef != null)
                        {
                            if (trigger.Type == TriggerType.Command)
                            {
                                (trigger as CommandTriggerDefinition).Command =
                                        commandDefinitionsList.SingleOrDefault(cd => cd.Name == nameRef);
                            }
                            else if (trigger.Type == TriggerType.Timer)
                            {
                                (trigger as TimerTriggerDefinition).Timer =
                                   timerDefinitionsList.SingleOrDefault(cd => cd.Name == nameRef);
                            }
                        }
                    }
                }

                ConditionDefinition condition = null;
                var conditionsElement = transitionElement.Element("Conditions");
                if (conditionsElement != null)
                {
                    var conditionElement = conditionsElement.Element("Condition");
                    if (conditionElement != null)
                    {
                        condition = !string.IsNullOrEmpty(GetNameRefNullable(conditionElement))
                                        ? ConditionDefinition.Create(GetType(conditionElement), actionDefinitionsList.Single(ad => ad.Name == GetNameRef(conditionElement)), GetResultOnPreExecution(conditionElement))
                                        : ConditionDefinition.Create(GetType(conditionElement), GetResultOnPreExecution(conditionElement));

                    }
                }

                var transition = TransitionDefinition.Create(GetName(transitionElement), GetClassifier(transitionElement), fromActivity,
                                                             toActivity, trigger, condition); 
                
                var restrictionsElement = transitionElement.Element("Restrictions");
                if (restrictionsElement != null)
                {
                    foreach (var element in restrictionsElement.Elements("Restriction"))
                    {
                        var item = actorDefinitionsList.FirstOrDefault(ad => ad.Name == GetNameRef(element));
                        if (item == null)
                        {
                            throw new Exception(); //Murad fix SchemeNotValidException(string.Format("Actor {0} not found", GetNameRef(element)));
                        }
                        transition.AddRestriction(RestrictionDefinition.Create(GetType(element),actorDefinitionsList.Single(ad=>ad.Name == GetNameRef(element))));
                    }
                }

                var onErrorsElement = transitionElement.Element("OnErrors");
                if (onErrorsElement != null)
                {
                    foreach (var element in onErrorsElement.Elements("OnError"))
                    {
                        //TODO Only One Type Of OnErrorHandler
                        transition.AddOnError(OnErrorDefinition.CreateSetActivityOnError(GetName(element), GetNameRef(element),GetPriority(element), GetTypeName(element)/*, GetIsExecuteImplementation(element),GetIsRethrow(element)*/));
                    }
                }
                transitions.Add(transition);
            }


            return transitions;
        }

        public override string ParseDesignerModel(XElement schemeMedium)
        {
            var item = schemeMedium.SingleOrDefault("DesignerModel");
            if (item == null)
                return string.Empty;
            else
                return item.Value;
        }

        public override string GetProcessName(XElement schemeMedium)
        {
            return GetName(schemeMedium);
        }

        private static string GetName(XElement element)
        {
            return GetSingleValue(element, "Name");
        }

        private static string GetValue(XElement element)
        {
            return GetSingleValue(element, "Value");
        }

        private static string GetRuleName(XElement element)
        {
            return GetSingleValue(element, "RuleName");
        }

        private static string GetOrder(XElement element)
        {
            return GetSingleValue(element, "Order");
        }

        private static string GetType(XElement element)
        {
            return GetSingleValue(element, "Type");
        }

        private static string GetDelay(XElement element)
        {
            return GetSingleValue(element, "Delay");
        }

        private static string GetInterval(XElement element)
        {
            return GetSingleValue(element, "Interval");
        }

        private static string GetMethodName(XElement element)
        {
            return GetSingleValue(element, "MethodName");
        }

        private static string GetTypeName(XElement element)
        {
            return GetSingleValue(element, "ExceptionType");
        }

        private static string GetId(XElement element)
        {
            return GetSingleValue(element, "Id");
        }

        private static string GetNameRef(XElement element)
        {
            return GetSingleValue(element, "NameRef");
        }

        private static string GetDefaultValue (XElement element)
        {
            return GetSingleValue(element, "DefaultValue");
        }

        private static string GetPriority(XElement element)
        {
            return GetSingleValue(element, "Priority");
        }

        private static string GetNameRefNullable(XElement element)
        {
            return GetSingleValue(element, "NameRef");
        }

        private static string GetResultOnPreExecution(XElement element)
        {
            return GetSingleValue(element, "ResultOnPreExecution");
        }

        private static string GetFrom(XElement element)
        {
            return GetSingleValue(element, "From");
        }

        private static string GetTo(XElement element)
        {
            return GetSingleValue(element, "To");
        }

        private static string GetIsFinal(XElement element)
        {
            return GetSingleValue(element, "IsFinal");
        }

        private static string GetIsForSetState(XElement element)
        {
            return GetSingleValue(element, "IsForSetState");
        }

        private static string GetIsAutoSchemeUpdate(XElement element)
        {
            return GetSingleValue(element, "IsAutoSchemeUpdate");
        }

        private static string GetIsInitial(XElement element)
        {
            return GetSingleValue(element, "IsInitial");
        }

        private static string GetClassifier(XElement element)
        {
            return GetSingleValue(element, "Classifier");
        }

        private static string GetState(XElement element)
        {
            return GetSingleValue(element, "State");
        }

        private static string GetObjectName(XElement element)
        {
            return GetSingleValue(element, "ObjectName");
        }

        private static string GetCulture(XElement element)
        {
            return GetSingleValue(element, "Culture");
        }

        private static string GetIsDefault(XElement element)
        {
            return GetSingleValue(element, "IsDefault");
        }

        private static string GetIsExecuteImplementation(XElement element)
        {
            return GetSingleValue(element, "IsExecuteImplementation");
        }

        private static string GetIsRethrow(XElement element)
        {
            return GetSingleValue(element, "IsRethrow");
        }

        private static string GetSingleValue(XElement el, string attName)
        {
            var a = el.Attributes(attName).SingleOrDefault();
            return a == null ? null : a.Value;
        }
    }
}
