using Switch_Off_on.Interfaces;
using Switch_Off_on.Models;

namespace Switch_Off_on.Commands
{
    // Конкретная команда для включения света
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }
}
