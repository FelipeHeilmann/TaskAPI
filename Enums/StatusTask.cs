using System.ComponentModel;

namespace TaskApi.Enums
{
    public enum StatusTask
    {
        [Description("A fazer")]
        toDO = 1,
        [Description("Em andamento")]
        doing = 2,
        [Description("Finalizada")]
        done = 3
    }
}