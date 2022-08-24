# IPJ-PachisiSpace-2022

Visão geral do jogo

Pachisi Space é um jogo de aventura puzzle implementado para ser jogado em tabuleiro multiplayer local baseado no jogo indiano Pachisi, Ludo King e Among Us. 

O público alvo do jogo são jogadores casuais de todas as idades, em especial o público que se identifica com a temática do jogo.
O Pachisi Space implementa as regras e alguns elementos visuais dos jogos Pachisi e Ludo King, sendo que no lugar das peças do tabuleiro tem-se os 
personagens do jogo Among Us.

Desse modo, o jogo ocorre em um tabuleiro com a temática espacial, onde os seus personagens são astronautas que estão em treinamento. O treinamento consiste em se 
dividir em equipes de quatro pessoas e a equipe que conseguir chegar primeiro à sala ganhará a chance de estar na missão de explorar um planeta desconhecido. O jogador 
deve coordenar a sua equipe para que todos consigam chegar à sala e comemorarem a ida a missão.
Pachisi é baseado em turnos, tal que por meio do mouse o jogador clica no dado, e o número que vier no dado será a quantidade de casas no tabuleiro que o personagem 
do jogador irá se mover até a chegada. Os desafios que o personagem irá enfrentar serão baseados na sorte de seus adversários, pois estes podem lançar poderes que 
podem dificultar o percurso. 
O jogo suporta 4 jogadores locais. Ao início de cada partida cada jogador poderá escolher a sua cor ou escolher o modo em que as cores são sorteadas para cada jogador. 
Cada cor terá um poder especial que quando selecionado poderá ser utilizado no adversário desejado para interferir no percurso deste. Cada jogador tem um tempo limite 
para realizar o seu movimento, caso contrário as suas ações ocorrem de forma randômica durante o turno. Assim, o time que conseguir trazer todos os seus integrantes 
para a sala primeiro recebe a missão de prêmio.

Mecânicas que serão implementadas

Um dos maiores desafios da implementação das mecânicas do jogo é a aleatorização dos dados de forma que o lançamento seja o mais próximo possível de dados reais.
Será necessário uma tela com as informações de status da partida, informando o turno do jogador, os pinos que chegaram no final, o lançamento dos dados e a tela de vitória.
O jogo possuirá as seguintes mecânicas:
    Cada cor possui uma habilidade;
    Possíveis poderes:
      Mover um pino para frente.
      Mover um pino para trás.
      Pular a jogada de algum jogador.
      Inverter a ordem de jogada.
      Mover um pino para o início.
      Mover um pino para uma casa aleatória.
    Encontrar um algoritmo para deixar o dado aleatório;
    Tabuleiro 15x15;
    Checkpoints;
    Cada personagem só pode mover os seus pinos, com exceção quando utilizado as habilidades;
    Construção da lógica:
      Jogador só sai do início se tirar o nº 6 e depois joga o dado novamente;
      Se o jogador tiver pelo menos um pino fora do início e tirar 6, poderá jogar novamente;
      Caso um pino sobreponha outro que não seja do mesmo jogador (mesma cor), o outro pino retorna para o início e o dado será jogado novamente;
      Contador de pinos que chegarem ao final do trajeto;
    No final, para o pino alcançar o objetivo, o número tem que ser igual ou menor do que o número de casas restantes. Ex: se o último pino/personagem está à 3 casas do objetivo, qualquer número maior que 3 implicará na perda da jogada;
    Lógica dos poderes:
      Cooldown: a cada “x” turnos, o poder pode ser ativado.
      Todos os jogadores possuem habilidades básicas e uma avançada (cada cor uma habilidade específica).

