
using SeaCucumber.Application;
using SeaCucumber.Domain;

Map map = MapCommandService.SetInitialMapState();

int nrOfSteps = MapCommandService.DetermineFirstStepWithoutMovement(map);

Console.WriteLine("Minimum number of steps:");
Console.WriteLine(nrOfSteps);