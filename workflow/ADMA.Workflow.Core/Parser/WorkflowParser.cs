using System.Collections.Generic;
using System.Linq;
using ADMA.Workflow.Core.Model;

namespace ADMA.Workflow.Core.Parser
{
    public abstract class WorkflowParser<TSchemeMedium>  : IWorkflowParser<TSchemeMedium> where TSchemeMedium : class
    {
        public abstract List<TimerDefinition> ParseTimers(TSchemeMedium schemeMedium);

        public abstract List<ActorDefinition> ParseActors(TSchemeMedium schemeMedium);

        public abstract List<LocalizeDefinition> ParseLocalization(TSchemeMedium schemeMedium);

        public abstract List<ParameterDefinition> ParseParameters(TSchemeMedium schemeMedium);

        public abstract List<CommandDefinition> ParseCommands(TSchemeMedium schemeMedium,
                                                     List<ParameterDefinition> parameterDefinitions);

        public abstract List<ActionDefinition> ParseActions(TSchemeMedium schemeMedium,
                                                   List<ParameterDefinition> parameterDefinitions);

        public abstract List<ActivityDefinition> ParseActivities(TSchemeMedium schemeMedium,
                                                        List<ActionDefinition> actionDefinitions);

        public abstract List<TransitionDefinition> ParseTransitions(TSchemeMedium schemeMedium,
                                                           List<ActorDefinition> actorDefinitions,
                                                           List<CommandDefinition> commandDefinitions,
                                                           List<ActionDefinition> actionDefinitions,
                                                           List<ActivityDefinition> activityDefinitions,
                                                           List<TimerDefinition> timerDefinitions);

        public abstract string ParseDesignerModel(TSchemeMedium schemeMedium);

        public abstract string GetProcessName(TSchemeMedium schemeMedium);

        public ProcessDefinition Parse(TSchemeMedium schemeMedium)
        {
            var localization = ParseLocalization(schemeMedium).ToList();
            var actors = ParseActors(schemeMedium).ToList();
            var timers = ParseTimers(schemeMedium).ToList();
            var parameters = ParseParameters(schemeMedium).ToList();
            var commands = ParseCommands(schemeMedium, parameters).ToList();
            var actions = ParseActions(schemeMedium, parameters).ToList();
            var activities = ParseActivities(schemeMedium, actions).ToList();
            var transitions = ParseTransitions(schemeMedium, actors, commands, actions, activities,timers).ToList();
            var designerModel = ParseDesignerModel(schemeMedium);

            return ProcessDefinition.Create(GetProcessName(schemeMedium),
                                            actors,
                                            parameters,
                                            commands,
                                            actions,
                                            activities,
                                            transitions,
                                            localization,
                                            designerModel);
        }        
    }
}
