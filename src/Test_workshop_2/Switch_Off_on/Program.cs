

using Switch_Off_on.Commands;
using Switch_Off_on.Models;
using Switch_Off_on;
using Switch_Off_on.Interfaces;

Light light = new Light();
ICommand lightOn = new LightOnCommand(light);
ICommand lightOff = new LightOffCommand(light);

RemoteControl remote = new RemoteControl();

// Включение света
remote.SetCommand(lightOn);
remote.PressButton();



// Отмена последней команды (включение света)
remote.PressUndo();



Console.ReadLine();

