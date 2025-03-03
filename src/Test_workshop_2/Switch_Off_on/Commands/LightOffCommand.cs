using Switch_Off_on.Interfaces;
using Switch_Off_on.Models;

namespace Switch_Off_on.Commands
{
    // Конкретная команда для выключения света
    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }
}
