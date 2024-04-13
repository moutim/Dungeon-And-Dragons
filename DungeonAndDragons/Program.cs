namespace DungeonAndDragons.Models;
using System;
using Microsoft.VisualBasic;

class Program
{
  private Room[] Rooms;
  private Room CurrentRoom;
  public static void Main()
  {
    Program program = new Program();
    program.RunGame();
  }

  private void RunGame()
  {
    Console.WriteLine("Bem vindo ao Dungeon Game!");
    Console.WriteLine("Para começar o jogo, escolha um nome e uma classe!");

    Console.WriteLine("Qual o seu nome pobre alma?");
    string nome = Console.ReadLine();
    
    string vocacao;
    do
    {
      Console.WriteLine("Escolha uma vocação: \n 1 - Guerreiro (100 de vida e 30 de ataque), \n 2 - Mago (80 de vida e 40 de ataque), \n 3 - Arqueiro (60 de vida e 50 de ataque)");
      vocacao = Console.ReadLine();

      switch (vocacao)
      {
        case "1":
          Console.WriteLine("Você escolheu Guerreiro!");
          break;
        case "2":
          Console.WriteLine("Você escolheu Mago!");
          break;
        case "3":
          Console.WriteLine("Você escolheu Arqueiro!");
          break;
        default:
          Console.WriteLine("Vocação inválida. Por favor, escolha uma opção entre 1 e 3.");
          vocacao = null;
          break;
      }
    } while (vocacao == null);


    Player jogador = new Player(nome, vocacao);

    Room[] rooms = CreateRooms();
    Rooms = rooms;

    CurrentRoom = Rooms[0];
    bool gameRunning = true;

    while (gameRunning)
    {

      Console.WriteLine("--------------------------------------");
      Console.WriteLine($"Escolha uma ação VocaçãoDoJogador/Nome:");
      Console.WriteLine("1. Mover para outra sala");
      Console.WriteLine("2. Ver status");
      Console.WriteLine("3. Desistir");
      Console.WriteLine("--------------------------------------");

      int option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          CurrentRoom.GetName();
          Console.WriteLine("Digite uma direção: norte, leste, sul ou oeste.");
          string direcao = Console.ReadLine();
          MovePlayer(direcao);
          CurrentRoom.GetName();
          CurrentRoom.GetMessage();
          break;
          case 2:
          showPlayerStatus();
          break;
          case 3:
          Console.WriteLine("Obrigado por jogar! Jogo encerrado.");
          gameRunning = false;
          break;
        default:
          Console.WriteLine("Escolha uma opção válida!");
          break;
      }
    }
  }

  public static void showPlayerStatus() {
        Console.WriteLine("Status do Jogador:");
        Player.GetName();
        Player.GetHealth();
        Player.GetVocation();
        Console.WriteLine("----------");
    }



  private static Room[] CreateRooms()
  {
    Room[] rooms = new Room[8];

    Enemy mummy = new Enemy("Mumia", 50, 10);
    Enemy orc = new Enemy("Orc", 50, 10);
    Enemy blackSkeleton = new Enemy("Esqueleto Negro", 50, 10);
    Enemy mage = new Enemy("Mago", 50, 10);

    Treasure key = new Treasure("Chave Enferrujada");
    Treasure potion = new Treasure("Poção de Cura");
    Treasure masterSword = new Treasure("Espada Mestra");

    Trap trapSala1 = new Trap(10);
    Trap trapSala5 = new Trap(20);

    Room room1 = new Room(
      message: "A sala está vazia, explore ao seu redor.",
      name: "Sala 1",
      trap: trapSala1,
      treasure: potion
    );

    Room room2 = new Room(
      message: "Existem inimigos ou tesouros nesta sala.",
      name: "Sala 2",
      enemy: orc,
      treasure: key
    );

    Room room3 = new Room(
      message: "Existem inimigos a sua frente. Esta sala também contem um velho baú, explore outras salas e encontre sua chave!",
      name: "Sala 3",
      enemy: blackSkeleton,
      treasure: masterSword

    );

    Room room4 = new Room(
      message: "A sala está vazia, explore ao seu redor.",
      name: "Sala 4"
    );

    Room room5 = new Room(
      message: "Existem inimigos ou tesouros nesta sala.",
      name: "Sala 5",
      trap: trapSala5
      
    );

    Room room6 = new Room(
      message: "Existem inimigos ou tesouros nesta sala.",
      name: "Sala 6",
      enemy: mummy
    );

    Room room7 = new Room(
      message: "Voce chegou ao desafio final, enfrente o Mago.",
     name: "Sala 7",
     enemy: mage
   );

    Room lobby = new Room(
          message: "Voce entrou na Dungeon, explore ao seu redor.",
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


    try
    {

      Room nextRoom = CurrentRoom.GetExits()[direction];
      CurrentRoom = nextRoom;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não há uma sala nessa direção.");
    }





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
