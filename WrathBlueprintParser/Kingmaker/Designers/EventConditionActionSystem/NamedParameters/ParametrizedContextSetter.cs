namespace Kingmaker.Designers.EventConditionActionSystem.NamedParameters;

public class ParametrizedContextSetter
{
    public ParameterEntry[] Parameters;

    public enum ParameterType
    {
        Unit,
        Locator,
        MapObject,
        Position,
        Blueprint,
        Float
    }

    public class ParameterEntry
    {
        public string Name;

        public ParameterType Type;

        public Element Evaluator;

        public override string ToString()
        {
            return $"{Type} {Name}({Evaluator})";
        }
    }
}
