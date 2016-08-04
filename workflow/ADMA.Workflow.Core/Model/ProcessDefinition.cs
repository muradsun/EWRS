using System;
using System.Collections.Generic;
using System.Linq;
using ADMA.Workflow.Core.Fault;
using System.Globalization;
using System.Xml.Linq;

namespace ADMA.Workflow.Core.Model
{


    public sealed class ProcessDefinition : BaseDefinition
    {
        public List<ActorDefinition> Actors { get; set; }
        public List<ParameterDefinition> Parameters { get; set; }
        public List<CommandDefinition> Commands { get; set; }
        public List<ActionDefinition> Actions { get; set; }
        public List<ActivityDefinition> Activities { get; set; }
        public List<TransitionDefinition> Transitions { get; set; }
        public List<LocalizeDefinition> Localization { get; set; }
        public string DesignerModel { get; set; }

        public ProcessDefinition()
        {
            Actors = new List<ActorDefinition>();
            Parameters = new List<ParameterDefinition>();
            Commands = new List<CommandDefinition>();
            Actions = new List<ActionDefinition>();
            Activities = new List<ActivityDefinition>();
            Transitions = new List<TransitionDefinition>();
            Localization = new List<LocalizeDefinition>();
            DesignerModel = string.Empty;
        }

        public ActivityDefinition InitialActivity
        {
            get
            {
                try
                {
                    var initialActivity = Activities.SingleOrDefault(a => a.IsInitial);
                    if (initialActivity == null)
                        throw new InitialActivityNotFoundException();
                    return initialActivity;
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
            }
        }

        public ParameterDefinition[] ParametersForSerialized
        {
            get
            {
                if (Parameters == null)
                    return null;

                return Parameters.Where(p => DefaultDefinitions.DefaultParameters.Count(p1 => p1.Name == p.Name) == 0).ToArray();
            }
        }            

        public ActivityDefinition FindActivity (string name)
        {
            var activity = Activities.SingleOrDefault(a => a.Name == name);
            if (activity == null)
                throw new ActivityNotFoundException();
            return activity;
        }

        public TransitionDefinition FindTransition(string name)
        {
            var transition = Transitions.SingleOrDefault(a => a.Name == name);
            if (transition == null)
                throw new TransitionNotFoundException();
            return transition;
        }

        public IEnumerable<TransitionDefinition> GetPossibleTransitionsForActivity (ActivityDefinition activity)
        {
            return Transitions.Where(t => t.From == activity);
        }

        public IEnumerable<TransitionDefinition> GetCommandTransitions(ActivityDefinition activity)
        {
            return Transitions.Where(t => t.From == activity && t.Trigger.Type == TriggerType.Command);
        }

        public IEnumerable<TransitionDefinition> GetAutoTransitionForActivity(ActivityDefinition activity)
        {
            return Transitions.Where(t => t.From == activity && t.Trigger.Type == TriggerType.Auto);
        }

        public IEnumerable<TransitionDefinition> GetCommandTransitionForActivity(ActivityDefinition activity, string commandName)
        {
            return Transitions.Where(t => t.From == activity && t.Trigger.Type == TriggerType.Command && t.Trigger.Command.Name == commandName);
        }

        public IEnumerable<TransitionDefinition> GetTimerTransitionForActivity(ActivityDefinition activity)
        {
            return Transitions.Where(t => t.From == activity && t.Trigger.Type == TriggerType.Timer);
        }


        public static ProcessDefinition Create(string name, List<ActorDefinition> actors, List<ParameterDefinition> parameters, List<CommandDefinition> commands,
           List<ActionDefinition> actions, List<ActivityDefinition> activities, List<TransitionDefinition> transitions, List<LocalizeDefinition> localization, string designerModel)
        {
            return new ProcessDefinition
                       {
                           Actions = actions,
                           Activities = activities,
                           Actors = actors,
                           Commands = commands,
                           Name = name,
                           Parameters = parameters,
                           Transitions = transitions,
                           Localization = localization,
                           DesignerModel = designerModel
                       };
        }

        public ParameterDefinition GetParameterDefinition(string name)
        {
            return Parameters.Single(p => p.Name.Equals(name,StringComparison.InvariantCultureIgnoreCase));
        }

        public ParameterDefinition GetNullableParameterDefinition(string name)
        {
            return Parameters.SingleOrDefault(p => p.Name == name);
        }

        public IEnumerable<ParameterDefinition> PersistenceParameters
        {
            get { return Parameters.Where(p => p.Purpose == ParameterPurpose.Persistence); }
        }

        #region Localized
        public string GetLocalizedStateName(string stateName, CultureInfo culture)
        {
            return GetLocalizedName(stateName, culture, LocalizeType.State);
        }

        public string GetLocalizedCommandName(string commandName, CultureInfo culture)
        {
            return GetLocalizedName(commandName, culture, LocalizeType.Command);
        }


        protected string GetLocalizedName(string name, CultureInfo culture, LocalizeType localizeType)
        {
            if (Localization == null)
                return name;                     

            var localize =
                Localization.FirstOrDefault(
                    l =>
                    l.Type == localizeType && string.Compare(l.Culture, culture.Name, true) == 0 &&
                    l.ObjectName == name);

            if (localize != null)
                return localize.Value;

            localize =
                Localization.FirstOrDefault(
                    l =>
                    l.Type == localizeType && l.IsDefault &&
                    l.ObjectName == name);

            if (localize != null)
                return localize.Value;

            return name;
        }
        #endregion

        public string Serialize()
        {
            XElement doc = new XElement("Process");
            doc.SetAttributeValue("Name", this.Name);

            #region Actors

            if (Actors.Count > 0)
            {
                XElement actors = new XElement("Actors");
                foreach (var item in Actors)
                {
                    XElement actor = new XElement("Actor");
                    actor.SetAttributeValue("Name", item.Name);

                    if (item is ActorDefinitionIsInRole)
                    {
                        var def = new XElement("IsInRole");
                        def.SetAttributeValue("Id", ((ActorDefinitionIsInRole)item).RoleId);
                        actor.Add(def);
                    }
                    else if (item is ActorDefinitionIsIdentity)
                    {
                        var def = new XElement("IsIdentity");
                        def.SetAttributeValue("Id", ((ActorDefinitionIsIdentity)item).IdentityId);
                        actor.Add(def);
                    }
                    else if (item is ActorDefinitionExecuteRule)
                    {
                        var ader = ((ActorDefinitionExecuteRule)item);

                        var rule = new XElement("Rule");
                        rule.SetAttributeValue("RuleName", ader.RuleName);

                        foreach (var rp in ader.ParametersDictionary)
                        {
                            var ruleParam = new XElement("RuleParameter");
                            ruleParam.SetAttributeValue(rp.Key, rp.Value);
                            rule.Add(ruleParam);
                        }
                        actor.Add(rule);
                    }
                    actors.Add(actor);   
                }
                
                doc.Add(actors);
            }   
            #endregion

            #region Parameters

            var parametersForSerialized = ParametersForSerialized;
            if (parametersForSerialized.Length > 0)
            {
                XElement parametrs = new XElement("Parameters");
                foreach (var item in parametersForSerialized)
                {
                    XElement itemXE = new XElement("Parameter");
                    itemXE.SetAttributeValue("Name", item.Name);
                    itemXE.SetAttributeValue("Type", item.Type);
                    itemXE.SetAttributeValue("Purpose", item.Purpose);
                    if(!string.IsNullOrEmpty(item.SerializedDefaultValue))
                        itemXE.SetAttributeValue("DefaultValue", item.SerializedDefaultValue);
                    parametrs.Add(itemXE);
                }

                doc.Add(parametrs);
            }   

            #endregion

            #region Commands

            if (Commands.Count > 0)
            {
                XElement commands = new XElement("Commands");
                foreach (var item in Commands)
                {
                    XElement itemXE = new XElement("Command");
                    itemXE.SetAttributeValue("Name", item.Name);

                    if (item.InputParameters.Count > 0)
                    {
                        XElement itemXESub = new XElement("InputParameters");
                        foreach (var itemSub in item.InputParameters)
                        {
                            XElement itemXESubParam = new XElement("ParameterRef");
                            itemXESubParam.SetAttributeValue("Name", itemSub.Key);
                            itemXESubParam.SetAttributeValue("NameRef", itemSub.Value.Name);
                            itemXESub.Add(itemXESubParam);
                        }
                        itemXE.Add(itemXESub);
                    }
                    commands.Add(itemXE);
                }
                doc.Add(commands);
            }
            #endregion

            #region Actions

            if (Actions.Count > 0)
            {
                XElement actions = new XElement("Actions");
                foreach (var item in Actions)
                {
                    XElement itemXE = new XElement("Action");
                    itemXE.SetAttributeValue("Name", item.Name);

                    XElement emItem = new XElement("ExecuteMethod");
                    emItem.SetAttributeValue("Type", item.FullTypeName);
                    emItem.SetAttributeValue("MethodName", item.MethodName);

                    if (item.InputParameters.Count() > 0)
                    {
                        XElement itemXESub = new XElement("InputParameters");
                        foreach (var itemSub in item.InputParameters)
                        {
                            XElement itemXESubParam = new XElement("ParameterRef");
                            itemXESubParam.SetAttributeValue("Order", itemSub.Order);
                            itemXESubParam.SetAttributeValue("NameRef", itemSub.Name);
                            itemXESub.Add(itemXESubParam);
                        }

                        emItem.Add(itemXESub);
                    }

                    if (item.OutputParameters.Count() > 0)
                    {
                        XElement itemXESub = new XElement("OutputParameters");
                        foreach (var itemSub in item.OutputParameters)
                        {
                            XElement itemXESubParam = new XElement("ParameterRef");
                            itemXESubParam.SetAttributeValue("Order", itemSub.Order);
                            itemXESubParam.SetAttributeValue("NameRef", itemSub.Name);
                            itemXESub.Add(itemXESubParam);
                        }

                        emItem.Add(itemXESub);
                    }

                    itemXE.Add(emItem);
                    actions.Add(itemXE);
                }
                doc.Add(actions);
            }
            #endregion

            #region Activities
            if (Activities.Count > 0)
            {
                XElement activities = new XElement("Activities");
                foreach (var item in Activities)
                {
                    XElement itemXE = new XElement("Activity");
                    itemXE.SetAttributeValue("Name", item.Name);
                    itemXE.SetAttributeValue("State", item.State);
                    itemXE.SetAttributeValue("IsInitial", item.IsInitial.ToString(CultureInfo.InvariantCulture));
                    itemXE.SetAttributeValue("IsFinal", item.IsFinal.ToString(CultureInfo.InvariantCulture));
                    itemXE.SetAttributeValue("IsForSetState", item.IsForSetState.ToString(CultureInfo.InvariantCulture));
                    itemXE.SetAttributeValue("IsAutoSchemeUpdate", item.IsAutoSchemeUpdate.ToString(CultureInfo.InvariantCulture));
                       
                    if (item.Implementation.Count() > 0)
                    {
                        XElement itemXESub = new XElement("Implementation");
                        foreach (var itemSub in item.Implementation)
                        {
                            XElement itemXESubParam = new XElement("ActionRef");
                            itemXESubParam.SetAttributeValue("Order", itemSub.Order);
                            itemXESubParam.SetAttributeValue("NameRef", itemSub.Name);
                            itemXESub.Add(itemXESubParam);
                        }

                        itemXE.Add(itemXESub);
                    }

                    if (item.PreExecutionImplementation.Count() > 0)
                    {
                        XElement itemXESub = new XElement("PreExecutionImplementation");
                        foreach (var itemSub in item.PreExecutionImplementation)
                        {
                            XElement itemXESubParam = new XElement("ActionRef");
                            itemXESubParam.SetAttributeValue("Order", itemSub.Order);
                            itemXESubParam.SetAttributeValue("NameRef", itemSub.Name);
                            itemXESub.Add(itemXESubParam);
                        }

                        itemXE.Add(itemXESub);
                    }

                    activities.Add(itemXE);
                }
                doc.Add(activities);
            }
            #endregion

            #region Transition
            if (Transitions.Count > 0)
            {
                XElement transitions = new XElement("Transitions");
                foreach (var item in Transitions)
                {
                    XElement itemXE = new XElement("Transition");
                    itemXE.SetAttributeValue("Name", item.Name);
                    itemXE.SetAttributeValue("To", item.To.Name);
                    itemXE.SetAttributeValue("From", item.From.Name);
                    itemXE.SetAttributeValue("Classifier", item.Classifier);

                    if (item.Restrictions.Count() > 0)
                    {
                        XElement itemXESub = new XElement("Restrictions");
                        foreach (var itemSub in item.Restrictions)
                        {
                            XElement itemXESubParam = new XElement("Restriction");
                            itemXESubParam.SetAttributeValue("Type", itemSub.Type);
                            if (itemSub.Actor != null)
                                itemXESubParam.SetAttributeValue("NameRef", itemSub.Actor.Name);
                            itemXESub.Add(itemXESubParam);
                        }
                        itemXE.Add(itemXESub);
                    }
                                        

                    //if (item.Trigger.Count() > 0)
                    {
                        XElement itemXESub = new XElement("Triggers");
                        //foreach (var itemSub in item.Restrictions)
                        {
                            var itemSub = item.Trigger;
                            XElement itemXESubParam = new XElement("Trigger");
                            itemXESubParam.SetAttributeValue("Type", itemSub.Type);

                            string nameRef = itemSub.NameRef;
                            if(!string.IsNullOrWhiteSpace(nameRef))
                                itemXESubParam.SetAttributeValue("NameRef", nameRef);
                            itemXESub.Add(itemXESubParam);
                        }
                        itemXE.Add(itemXESub);
                    }

                    //if (item.Condition.Count() > 0)
                    {
                        XElement itemXESub = new XElement("Conditions");
                        //foreach (var itemSub in item.Restrictions)
                        {
                            var itemSub = item.Condition;
                            XElement itemXESubParam = new XElement("Condition");
                            itemXESubParam.SetAttributeValue("Type", itemSub.Type);
                            if(itemSub.Action != null)
                                itemXESubParam.SetAttributeValue("NameRef", itemSub.Action.Name);
                            itemXESub.Add(itemXESubParam);
                        }
                        itemXE.Add(itemXESub);
                    }

                    transitions.Add(itemXE);
                }
                doc.Add(transitions);
            }
            #endregion

            #region Localization
            if (Localization.Count > 0)
            {
                XElement localization = new XElement("Localization");
                foreach (var item in Localization)
                {
                    XElement itemXE = new XElement("Localize");
                    itemXE.SetAttributeValue("Type", item.Type);
                    itemXE.SetAttributeValue("IsDefault", item.IsDefault.ToString(CultureInfo.InvariantCulture));
                    itemXE.SetAttributeValue("Culture", item.Culture);
                    itemXE.SetAttributeValue("ObjectName", item.ObjectName);
                    itemXE.SetAttributeValue("Value", item.Value);
                    localization.Add(itemXE);
                }

                doc.Add(localization);
            }   
            #endregion

            #region DesignerModel

            if (!string.IsNullOrWhiteSpace(DesignerModel))
            {
                XElement dm = new XElement("DesignerModel");
                dm.Add(new XCData(DesignerModel));
                doc.Add(dm);
            }
            #endregion
            
            return doc.ToString();     
        }
    }
}
