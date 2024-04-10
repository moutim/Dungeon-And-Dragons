namespace DungeonAndDragons.Models;
using System;
using Microsoft.VisualBasic;

class Program
{
  public static void Main()
  {
    Program program = new Program(); // Criando uma instância de Program.
    program.RunGame(); // Chamando o método RunGame da instância criada.
  }

  private Room[] Rooms;
  private Room CurrentRoom;

  private void RunGame()
  {
    Console.WriteLine("Bem vindo ao Dungeon Game!");
    Console.WriteLine("Para começar o jogo, escolha um nome e uma classe!");

    Console.WriteLine("Qual o seu nome?");
    string nome = Console.ReadLine();

    Console.WriteLine("Escolha uma vocação: 1 - Guerreiro, 2 - Mago, 3 - Arqueiro");
    string vocacao = Console.ReadLine();

    Player jogador = new Player(nome, 100, vocacao);

    Room[] rooms = CreateRooms();
    Rooms = rooms;

    CurrentRoom = Rooms[0];
    bool gameRunning = true;

    while (gameRunning)
    {
      Console.WriteLine("Escolha uma ação:");
      Console.WriteLine("1. Mover para outra sala (Norte, Sul, Leste, Oeste)");
      Console.WriteLine("2. Ver status");
      Console.WriteLine("3. Desistir");

      int option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          CurrentRoom.GetName();
          string direcao = Console.ReadLine();
          MovePlayer(direcao);
          Console.WriteLine(CurrentRoom.GetName());
          break;
        default:
          Console.WriteLine("Escolha uma opção válida!");
          break;
      }
    }
  }

  private static Room[] CreateRooms()
  {
    Room[] rooms = new Room[8];

    Enemy enemy1 = new Enemy("Goblin", 50, 10);
    Enemy enemy2 = new Enemy("Esqueleto", 50, 10);
    Enemy orc = new Enemy("Orc", 50, 10);
    Enemy enemy3 = new Enemy("Caveira", 50, 10);
    Enemy enemy4 = new Enemy("Zumbi", 50, 10);

    Treasure treasure1 = new Treasure("Espada");
    Treasure potion = new Treasure("Poção de Cura");
    Treasure treasure3 = new Treasure("Tridente");

    Trap trapSala1 = new Trap(10);
    Trap trap2 = new Trap(20);
    Trap trap3 = new Trap(30);

    Room room1 = new Room(
      name: "Sala 1",

      trap: trapSala1
    );




    Room room2 = new Room(
      name: "Sala 2",
      enemy: orc,
      treasure: potion
    );

    Room room3 = new Room(
      name: "Sala 3",
      enemy: orc,
      treasure: potion
    );

    Room room4 = new Room(
      name: "Sala 4"
    );

    Room room5 = new Room(
      name: "Sala 5"

    );

    Room room6 = new Room(
      name: "Sala 6"
    );

    Room room7 = new Room(
     name: "Sala 7"
   );

    Room lobby = new Room(
          name: "Saguão"

        );

    lobby.AddExit("oeste", room1);
    lobby.AddExit("sul", room3);
    lobby.AddExit("leste", room4);

    room1.AddExit("leste", lobby);
    room1.AddExit("norte", room2);

    room2.AddExit("sul", room1);

    room3.AddExit("norte", lobby);

    room4.AddExit("oeste", lobby);
    room4.AddExit("sul", room5);

    room5.AddExit("norte", room4);
    room5.AddExit("sul", room6);

    room6.AddExit("norte", room5);
    room6.AddExit("leste", room7);

    rooms[0] = lobby;
    rooms[1] = room1;
    rooms[2] = room2;
    rooms[3] = room3;
    rooms[4] = room4;
    rooms[5] = room5;
    rooms[6] = room6;
    rooms[7] = room7;




    return rooms;
  }

  public void MovePlayer(string direction)
  {
    Room nextRoom = CurrentRoom.GetExits()[direction];

    if (nextRoom == null)
    {
      Console.WriteLine("Não há uma sala nessa direção.");
    }
    else
    {
      CurrentRoom = nextRoom;
      Console.WriteLine("Você entrou na sala: " + CurrentRoom.GetName());

      // int trapDamage = currentRoom.ActivateTrap();
      // if (trapDamage > 0)
      // {
      //     Console.WriteLine("Você ativou uma armadilha e sofreu " + trapDamage + " de dano!");
      //     player.ReduceHealth(trapDamage);
      // }

      // if (currentRoom.GetEnemies().Length == 0 && currentRoom.GetTreasures().Length == 0)
      // {
      //     Console.WriteLine("A sala está vazia. Continue explorando.");
      // }
      // else
      // {
      //     Console.WriteLine("Há inimigos ou tesouros nesta sala. Tome cuidado!");
      // }
    }
  }
}