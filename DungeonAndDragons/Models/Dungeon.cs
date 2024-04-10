// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace DungeonAndDragons.Models
// {
//     public class Dungeon
//     {
//         private Room currentRoom;
//     private bool gameOver;

//     public Dungeon()
//     {
//         // Inicializa a masmorra com as salas e configurações iniciais
//         // Implemente a lógica de criação das salas, inimigos, armadilhas e tesouros aqui
//         currentRoom = new Room("Sala Inicial");
//         gameOver = false;
//     }

//     public bool IsGameOver()
//     {
//         return gameOver;
//     }

//     public void PrintCurrentRoomInfo()
//     {
//         // Exibe informações da sala atual (ex: descrição, inimigos, tesouros, etc.)
//         Console.WriteLine("Você está na sala: " + currentRoom.GetName());
//         // Implemente a lógica para exibir informações adicionais da sala
//     }

//     public void PrintActions()
//     {
//         // Exibe as ações disponíveis para o jogador
//         Console.WriteLine("Escolha uma ação:");
//         Console.WriteLine("1. Mover para outra sala");
//         Console.WriteLine("2. Atacar inimigo");
//         Console.WriteLine("3. Coletar tesouro");
//         // Implemente outras ações disponíveis no jogo
//     }

//     public void ProcessAction(string action)
//     {
//         // Processa a ação do jogador
//         switch (action)
//         {
//             case "1":
//                 MovePlayer(); // Implemente a lógica para mover o jogador para outra sala
//                 break;
//             case "2":
//                 AttackEnemy(); // Implemente a lógica para o jogador atacar um inimigo
//                 break;
//             case "3":
//                 CollectTreasure(); // Implemente a lógica para o jogador coletar um tesouro
//                 break;
//             default:
//                 Console.WriteLine("Ação inválida!");
//                 break;
//         }
//     }

//     private void MovePlayer()
//     {
//         Console.WriteLine("Digite o número da sala para onde você deseja se mover:");
//         int roomNumber = Convert.ToInt32(Console.ReadLine());

//         // Implemente a lógica para mover o jogador para a sala desejada
//         // Certifique-se de verificar se o número da sala é válido

//         // Exemplo simplificado: mover o jogador para a sala seguinte
//         currentRoom = new Room("Sala " + roomNumber);
//     }

//     private void AttackEnemy()
//     {
//         Room currentRoom = GetCurrentRoom();
//         List<Enemy> enemies = currentRoom.GetEnemies();

//         if (enemies.Count == 0)
//         {
//             Console.WriteLine("Não há inimigos nesta sala!");
//             return;
//         }

//         // Exibe os inimigos disponíveis para atacar
//         Console.WriteLine("Inimigos disponíveis para atacar:");
//         for (int i = 0; i < enemies.Count; i++)
//         {
//             Console.WriteLine((i + 1) + ". " + enemies[i].GetName());
//         }

//         Console.WriteLine("Escolha o número do inimigo para atacar:");
//         int enemyNumber = Convert.ToInt32(Console.ReadLine());

//         if (enemyNumber < 1 || enemyNumber > enemies.Count)
//         {
//             Console.WriteLine("Número de inimigo inválido!");
//             return;
//         }

//         Enemy enemy = enemies[enemyNumber - 1];


//         // Realiza o ataque do jogador ao inimigo
//         int damageDealt = player.Attack(enemy);
//         enemy.ReduceHealth(damageDealt);

//         Console.WriteLine("Você atacou o inimigo " + enemy.GetName() + " e causou " + damageDealt + " de dano.");

//         // Verifica se o inimigo foi derrotado
//         if (enemy.IsDefeated())
//         {
//             currentRoom.RemoveEnemy(enemy);
//             Console.WriteLine("Você derrotou o inimigo " + enemy.GetName() + "!");
//         }
//     }

//     private Room GetCurrentRoom()
//     {
//         return this.currentRoom;
//     }
//     }
// }