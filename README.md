# Game Of Drones

In Game of Drones there are two players trying to conquer each other.
Players take turns to make their move, choosing Paper, Rock or Scissors. Each move
beats another, just like the game “Paper, rock, scissors”.
Like so:

 - Paper beats rock
 - Rock beats scissors
 - Scissors beats paper

The first player to beat the other player 3 times wins the battle.

## Demo

Here's a online [demo](http://gameofdrones.azurewebsites.net).
> This is the easiest way to start to play!

## Assumption
The application is not case sensitive for the player's name. So **JOHN** is the same **john**

## Run the application locally
- Clone this repo.
- Go to `backend` folder.
- Open solution in Visual Studio.
- Run the project.
- Go to `frontend` folder.
- Set connection string to your local backend in `environment.ts`
- Run `npm install`
- Run `ng serve`
- Navigate to `http://localhost:4200/`