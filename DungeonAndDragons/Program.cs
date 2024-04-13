namespace DungeonAndDragons.Models;
using System;
using Microsoft.VisualBasic;

class Program
{
  private Room[] Rooms;
  private Room CurrentRoom;
  private Player Jogador;
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

    Jogador = new Player(nome, vocacao);

    Room[] rooms = CreateRooms();
    Rooms = rooms;

    CurrentRoom = Rooms[0];
    bool gameRunning = true;

    while (gameRunning)
    {
      Console.WriteLine("--------------------------------------");
      Console.WriteLine("Escolha uma ação:");
      Console.WriteLine("1. Mover para outra sala");
      Console.WriteLine("2. Ver status");
      Console.WriteLine("3. Desistir");
      Console.WriteLine("--------------------------------------");

      int option = int.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          Console.WriteLine("Digite uma direção: norte, leste, sul ou oeste.");
          string direcao = Console.ReadLine();
          MovePlayer(direcao);
          break;
        case 2:
          showPlayerStatus();
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

    Enemy mummy = new Enemy("Mumia", 50, 10);
    Enemy orc = new Enemy("Orc", 50, 10);
    Enemy blackSkeleton = new Enemy("Esqueleto Negro", 50, 10);
    Enemy mage = new Enemy("Mago", 50, 10);

    Treasure key = new Treasure("Chave Enferrujada");
    Treasure potion = new Treasure("Poção de Cura");
    Treasure masterSword = new Treasure("Espada Mestra");

    Trap trapSala5 = new Trap(20);

    Room room1 = new Room(
      message: "A sala está vazia, explore ao seu redor.",
      name: "Sala 1"
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

      Console.WriteLine("-------//-------//-------");
      CurrentRoom.GetMessage();
      CurrentRoom.GetName();

      Enemy? enemyRoom = CurrentRoom.GetEnemies();
      string? treasureRoom = CurrentRoom.GetTreasures();

      if (enemyRoom != null)
      {
        Console.WriteLine("-------//-------//-------");

        Console.WriteLine($"Você encontrou um {enemyRoom.GetName()} com {enemyRoom.GetHealth()} de vida");
        Console.WriteLine($"O {enemyRoom.GetName()} começa atacando e você toma {enemyRoom.Attack} de dano");

        Jogador.ReduceHealth(enemyRoom.Attack);

        while (!enemyRoom.IsDefeated())
        {
          Console.WriteLine("--------------------------------------");
          Console.WriteLine("Escolha uma opção:");
          Console.WriteLine("1 - Atacar:");
          Console.WriteLine("2 - Ver status:");

          int option = int.Parse(Console.ReadLine());

          if (option == 1)
          {
            Console.WriteLine($"Você faz um ataque de {Jogador.GetAttack()} de dano com o {Jogador.Weapon} no inimigo!");
            enemyRoom.ReduceHealth(Jogador.GetAttack());

            if (enemyRoom.GetHealth() <= 0)
            {
              Console.WriteLine($"Com esse ataque o {enemyRoom.GetName()} da seu último suspiro e morre");

              if (CurrentRoom.Name == "Sala 2") {
                Console.WriteLine($"Ao cair, o {enemyRoom.GetName()} deixa uma {CurrentRoom.GetTreasures()} cair e você pega ela. Pode ser útil para abrir alguma coisa.");
                Jogador.Key = CurrentRoom.GetTreasures();
              }
              
            }
            else
            {
              Console.WriteLine($"O {enemyRoom.GetName()} revida e você toma {enemyRoom.Attack} de dano");
              Jogador.ReduceHealth(enemyRoom.Attack);

              Console.WriteLine($"O {enemyRoom.GetName()} agora está com {enemyRoom.GetHealth()} de vida");
            }
          }
          else if (option == 2)
          {
            showPlayerStatus();
          }
        }

      }
    
      if (treasureRoom != null) {
        if (CurrentRoom.Name == "Sala 3") {
          Console.WriteLine("Existe um baú trancado nesta sala, parece que tem uma fechadura para uma velha chave enferrujada.");
          if (Jogador.Key != null) {
            Console.WriteLine($"A {Jogador.Key} está com você!");
            Console.WriteLine($"Você abre o baú e ganha a {CurrentRoom.GetTreasures()}");

            Jogador.ChangeAttack(100);
            Jogador.Weapon = CurrentRoom.GetTreasures();
          }
        }
      }
    
      // if (CurrentRoom.Name == "Sala 5")
      // {
      //   Console.WriteLine($"Você pisa em uma armadilha e perder {CurrentRoom.GetTrap().GetDamage()} de dano");
      //   Jogador.ReduceHealth(CurrentRoom.GetTrap().GetDamage());
      // }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não há uma sala nessa direção.");
    }
  }

  public static void showPlayerStatus() {
        Console.WriteLine("Status do Jogador:");
        Player.GetName();
        Player.GetHealth();
        Player.GetVocation();
        Console.WriteLine("----------");
    }
}
