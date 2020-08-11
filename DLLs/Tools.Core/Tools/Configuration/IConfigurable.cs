namespace Tools.Core.Tools.Configuration
{
    public interface IConfigurable<out T>
    {
        T GetConfig();
    }
}