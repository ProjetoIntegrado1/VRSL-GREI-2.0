# VRSL-GREI-2.0

<h4>
  Sumário: 
 <a href="#sobre">Sobre</a> • 
 <a href="#membros">Membros</a> • 
 <a href="#license">Licença</a> • 
 <a href="#requisitos">Requisitos</a> •
 <a href="#tecnologias">Tecnologias</a> •
 <a href="#guia-de-instalacao">Guia de instalação</a> •
 <a href="#estrutura-de-pastas">Estrutura de pastas</a> •
 <a href="#documento">Relatório e Apresentação</a> •
 <a href="#executavel">Executável</a> •
</h4>

<a name="sobre"></a>

## Sobre  
VRSL é um simulador de subestações de energia, baseado na subestação da Universidade Federal do Ceará (UFC), sendo utilizado em sala de aula principalmente para a cadeira de Geração, Distribuição e Transmissão do curso de Engenharia Elétrica da UFC.
Ele foi originalmente desenvolvido pelo Grupo de Redes Elétricas Inteligentes (GREI).

<a name="membros"></a>

## Membros

|  NOME                                     |  FUNÇÃO                           |
|  --------------------------------------   |  -------------------------------  |
|  **Antônio Lucas Vieira de Lima**         |  Gestão e Design                  | 
|  **Henrique Segundo da Fonseca**          |  Design, Documentação e Avaliação |
|  **João Amauri Rodrigues do Nascimento**  |  Codificação                      |
|  **John Lennon Fernandes de Andrade**     |  Design e Documentação            |
|  **Luana Moreira Dias**                   |  Codificação                      |
|  **Luis Henrique da Costa Silva**         |  Design                           |

<a name="license"></a>

## Licença
Este código está sobre a licença CC0 1.0 Universal. Para mais informações, veja o [LICENSE](LICENSE).

<a name="requisitos"></a>

## Requisitos

| ID      | Title                                          | Description                                                                                                                                                                                                                                                                  | Priority | Status      | Arquivo / Implementação                                                                                                                                                         |
| ------- | ------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------- | --------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| VSRF 01 | Mudar de área                                  | **COMO** usuário, **QUERO** alternar entre os diferentes mapas do simulador de forma rápida. **PARA** que a aula ou minha atividade de casa prossiga de forma fluída.                                                                                                        | High     | Done        | 📄 [**FirstPersonController.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/FirstPersonController.cs) e 📄 [**GameManager.cs**](Assets/Scripts/GameManager.cs) - O método `Warp()` é definido no `FirstPersonController.cs` e muda a posição e rotação do jogador conforme entregado ao método, o `GameManager.cs` tem os métodos de mudar de cena em conjunto com os teleporte com as posições e rotações adequadas, que são chamadas nos botões de teleporte implementados na HUD. Se estiver fora da cena alvo ele muda para a cena alvo. |
| VSRF 02 | Visualizar Diagramas                           | **COMO** usuário, **QUERO** visualizar os diferentes diagramas que são utilizados em uma subestação. **PARA** conseguir demonstrar os conteúdos vistos em cadeiras anteriores sendo utilizados em prática com componentes “reais”.                                           | High     | Done |  Há formas de acessar diagramas tanto no menu principal quanto no ambiente 3d, as do ambiente 3d sendo através da HUD ou do notebook |
| VSRF 03 | Visualizar Missões/Objetivos                   | **COMO** usuário, **QUERO** visualizar meus próximos passos para o andamento da aula e/ou atividade de forma que possua um roteiro coeso. **PARA** não ficar perdido e ter meu aprendizado possivelmente prejudicado.                                                        | High     | Done       | Dentro do ambiente 3d há uma tela de objetivos no canto da tela (HUD), e no menu acessavel pelo ESC ou pelo botão no HUD há uma sessão de objetivos expandida      |
| VSRF 04 | Selecionar roteiro                             | **COMO** usuário, **QUERO** selecionar qual conjunto de missões/atividades irei realizar para as atividades que irei realizar em sala ou em casa. **PARA** manter uma linha de aprendizado que não me deixe confuso quanto a onde estou e o que estou fazendo na subestação. | Low      | Backlog       | —                                                                                                                                                                               |
| VSRF 05 | Menu inicial                                   | **COMO** usuário, **QUERO** um menu inicial amigável e intuitivo que permita a manipulação por um único operador. **PARA** que como professor, não necessite de um terceiro para auxiliar com o simulador durante a aula.                                                    | High     | Done |  O menu inicial possui botões legiveis e diretos, contendo icones e textos para melhor compreensão do seu funcionamento   |
| VSRF 06 | Visualizar Informações dos componentes                         | **COMO** usuário, **QUERO** visualizar informações sobre componentes presentes na subestação. **PARA** aprender mais sobre como aqueles componentes funcionam e auxiliam no funcionamento da subestação.                                                                     | Medium   | Done      |  Ao interagir com a maioria dos componentes abrirá uma camera com uma tela que explica sobre o componente                    |
| VSRF 07 | Navegar de forma fluida                        | **COMO** usuário, **QUERO** utilizar o programa sem travamentos e/ou quedas de FPS em minha máquina. **PARA** conseguir utilizar o simulador em máquinas que não sejam potentes, como as da minha casa.                                                                      | Low      | Backlog       | —                                                                                                                                                                               |
| VSRF 08 | Alternar rapidamente entre pontos de interesse | **COMO** usuário, **QUERO** visitar rapidamente locais da subestação. **PARA** minimizar o tempo que posso acabar perdendo, seja em sala de aula ou em casa, navegando de um ponto a outro da subestação.                                                                    | Medium   | Done        | 📄 [**FirstPersonController.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/FirstPersonController.cs) e 📄 [**GameManager.cs**](Assets/Scripts/GameManager.cs) - O método `Warp()` é definido no `FirstPersonController.cs` e muda a posição e rotação do jogador conforme entregado ao método, o `GameManager.cs` tem os métodos de mudar de cena em conjunto com os teleporte com as posições e rotações adequadas, que são chamadas nos botões de teleporte implementados na HUD. Se estiver dentro da cena alvo ele muda a posição e rotação do jogador. |
| VSRF 09 | Surgir no mapa                                 | **COMO** usuário, **QUERO** adentrar no ambiente 3D de modo a visualizar os principais pontos de interesse. **PARA** já na primeira observação, conseguir ver os pontos principais da subestação.                                                                            | High     | Done        | Foi alterada a posição e rotação inicial do `Transform` no `Inspector` do jogador. |
| VSRF 10 | Visualizar Controles                           | **COMO** usuário, **QUERO** visualizar o esquema de botões utilizado no simulador de forma objetiva e simples. **PARA** não ficar perdido e/ou confuso durante a navegação na subestação.                                                                                    | High     | Done |  Antes de acessar o ambiente 3d há uma tela que exibe todos os controles que serão utilizados                                               |
| VSRF 11 | Movimentar pelo mapa                           | **COMO** usuário, **QUERO** que o esquema de botões seja o mais simples possível e ao mesmo tempo intuitivo para que consiga andar pelo mapa sem problemas. **PARA** que, mesmo não sendo tão letrado digitalmente, consiga utilizar o simulador de forma satisfatória.      | High      | Done |  Há um esquema de botões simples, seja usando icones de facil entendimento ou textos com tamanho legivel                                         |
| VSRF 12 | Soltar mouse durante a crosshair               | **COMO** usuário, **QUERO** soltar o mouse durante a mira para apertar nos botões da HUD. **PARA** interagir com a interface e não precisar usar os atalhos de teclado.                                                                                                      | High     | Done        | 📄 [**MenuSystem.cs**](Assets/Scripts/MenuSystem.cs) - No `Update()` chama o método `HandleAltRightToggle()`, que aguarda o input de soltar o mouse `Alt` ou `Clique Direito` e conforme o tempo do jogo estiver pausado ou não ele chama os métodos `ResumeGame()` ou `PauseGame()` e por consequência prende ou solta o mouse. |
| VSRF 13 | Hover em objetos interagíveis                  | **COMO** usuário, **QUERO** que os objetos interagíveis possuam um efeito de hover outline. **PARA** identificar visualmente o que pode ser interagido na cena.                                                                                                              | High     | Done        | 📄 [**HoverOutline.cs**](Assets/Scripts/HoverOutline.cs) - Configura, ativa e desativa a outline conforme o raycast do mouse no `Update()`.|
| VSRF 14 | Mostrar todos objetos interativos              | **COMO** usuário, **QUERO** apertar um botão para mostrar todos os objetos interagíveis da cena. **PARA** ter uma visão geral rápida dos pontos disponíveis para interação.   | Medium   | Done        | 📄 [**MenuSystem.cs**](Assets/Scripts/MenuSystem.cs) - Ao apertar `i` ou o botão de interação na HUD, chama o método `ToggleAllOutlines()` que varre `FindObjectsOfType<Outline>()` e inverte o enable de todas as outlines encontradas.  |
| VSRF 15 | Menu in‑game / Tablet | **COMO** usuário, **QUERO** apertar um botão dentro do ambiente 3D para abrir um menu que me permita acessar diversas opções (diagramas, roteiros, configurações, voltar ao menu inicial e fechar o simulador). **PARA** gerenciar as funcionalidades do simulador de forma rápida e sem interromper a experiência.   | High   | Done    | Na HUD há um botão para acessar o diagrama principal, e também um botão para acessar o menu, nele haverá a sessão de Objetivos como os objetivos do roteiro e o menu do ambiente 3d, que por sua vez acessa as configurações ou sai do simulador |

## BugFix

| ID      | Title                      | Description                                                                                                                                                    | Priority | Status      | Arquivo / Implementação                                                                                                       |
| ------- | -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- | ----------- | ----------------------------------------------------------------------------------------------------------------------------- |
| VSBF 01 | Menus sobrepostos          | **COMO** usuário, **QUERO** que os menus não se sobreponham entre si. **PARA** evitar confusão e conflitos com o sistema de movimentação.                      | High     | Done        | 📄 [**MenuSystem.cs**](Assets/Scripts/MenuSystem.cs) - Foi implementado um `enum MenuState { Crosshair, TabletMenu, OtherMenu }` para gerenciar os estados e conforme menus são abertos, dessa forma ao apertar `ESC` ou `TAB` (botões que abrem menus), eles fecham os menus atuais voltando para o `state Crosshair` e nesse estado é possível abrir os menus com os botões, impedindo a sobreposições de menus. |
| VSBF 02 | Caixa de seleção de Botões | **COMO** usuário, **QUERO** que a área de clique dos botões no menu inicial tenha o tamanho adequado. **PARA** não acionar o botão ao clicar fora de sua área. | High     | Done | O tamanho das caixas de colisão dos botões foi ajustado no `Editor` da cena `MENU` e dessa forma não há mais zonas invisíveis clicáveis. |
| VSBF 03 | Desativar interação com hover durante menus | **COMO** usuário, **QUERO** que a interação por hover em objetos não funcione enquanto qualquer menu estiver aberto. **PARA** evitar cliques e contornos indesejados sobre interfaces de menu. | Medium   | Done        | 📄 [**MenuSystem.cs**](Assets/Scripts/MenuSystem.cs), 📄 [**HoverOutline.cs**](Assets/Scripts/HoverOutline.cs), 📄 [**S_MouseInteragir.cs**](Assets/Scenes/Cena%20do%20Transformador/Script%20na%20Nova%20Cena/S_MouseInteragir.cs) e 📄 [**S_MouseInteragir_2.cs**](Assets/Scenes/Cena%20do%20Transformador/Script%20na%20Nova%20Cena/S_MouseInteragir_2.cs) - No `Update()` deles é realizada uma checagem se o estado de MenuState é Crosshair, se sim continua a execução do código da outline, se não retorna e impede de continuar.|
| VSBF 04 | Acelerar abertura de portas                 | **COMO** usuário, **QUERO** que as portas abram mais rápido ao interagir. **PARA** manter o fluxo da experiência de forma dinâmica.                                                            | Low      | Done        | No `Animation` das portas presentes na cena `Treinamento` foi reduzido pela metade o tempo da animação de abrir/fechar. |
| VSBF 05 | Corrigir colisão em mapa do transformador   | **COMO** usuário, **QUERO** evitar bugar a colisão no mapa do transformador. **PARA** não cair fora dos limites da cena e interferir na experiência de uso.                      | Low      | Done        | O problema da colisão foi identificado somente na mesa do notebook da cena `Transformador`, então foi copiado o objeto correspondente na cena `Treinamento` a ajustado conforme a necessidade de posição e rotação. |
| VSBF 06 | Limitar rotação vertical   | **COMO** usuário, **QUERO** limitar a rotação da câmera a 90° para cima e 90° para baixo. **PARA** evitar giros completos de 360° desorientadores.                          | Low      | Done        | 📄 [**MouseLook.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/MouseLook.cs) - Foi refatorado para usar variável de pitch com `Mathf.Clamp(MinimumX, MaximumX)`, assim impedindo que o jogador consiga rotacionar 360 graus. |
| VSBF 07 | Movimentação precisa       | **COMO** usuário, **QUERO** que o personagem ande precisamente na direção pressionada sem inclinação lateral. **PARA** melhorar o controle e evitar movimentos indesejados. | Low      | Done        | Foi identificado que a câmera do jogador estava com uma rotação no eixo Y do `Transform.Rotation`, dessa forma foi só ajustar para se comportar exatamente igual a rotação do jogador, ao entregar a mesma rotação inicial. |

<a name="tecnologia"></a>

## Tecnologias 
### Unity Engine, C# e Blender
<img align="center" alt="Rafa-Unity" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/unity/unity-original.svg">  <img align="center" alt="Rafa-Csharp" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">  <img align="center" alt="Rafa-Unity" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/blender/blender-original.svg">

*Blender não foi utilizado para Projeto I, ele é só um requisito do editável, pois existem arquivos .blend

<a name="guia-de-instalacao"></a>

## Guia de Instalação

Siga os passos abaixo para configurar e executar este projeto Unity corretamente no seu computador.

### 1. Baixar e Instalar o Unity Hub, o Unity Editor e o Blender

1. Acesse: [https://unity.com/download](https://unity.com/download)
2. Faça o download do Unity Hub para o seu sistema operacional.
3. No Unity Hub, instale a versão **2022.3.32f1** do Unity Editor.
4. Acesse: [https://www.blender.org/download](https://www.blender.org/download)
5. Faça o download do Blender para o seu sistema operacional.

### 2. Clonar o Repositório

1. Abra o terminal (ou Git Bash).
2. Execute o comando abaixo, substituindo pelo link correto do repositório:

```bash
git clone https://github.com/ProjetoIntegrado1/VRSL-GREI-2.0
```

### 3. Baixar os Arquivos Grandes (Acima de 100 MB)

Alguns arquivos não podem ser versionados diretamente no GitHub e estão disponíveis nos **Releases** do repositório:

1. Acesse: [https://github.com/ProjetoIntegrado1/VRSL-GREI-2.0/releases](https://github.com/ProjetoIntegrado1/VRSL-GREI-2.0/releases)
2. Faça o download dos arquivos.
3. Copie cada arquivo para a pasta indicada dentro do diretório clonado (verifique o nome e caminho em cada release).

### 4. Abrir o Projeto no Unity Hub

1. No Unity Hub, clique em **Add** (Adicionar).
2. Navegue até a pasta do projeto que você clonou e a adicione.
3. Execute no Unity Hub e aguarde o carregamento e a indexação de assets pelo Unity.

<a name="estrutura-de-pastas"></a>

## Estrutura de Pastas

```
├── .gitignore
├── .vsconfig
├── Assets
│ ├── Animation/ # Animações personalizadas do projeto
│ ├── Models/ # Modelos 3D importados
│ ├── Materials/ # Materiais e texturas customizadas
│ ├── Imagens/ # Sprites e imagens de UI
│ ├── Sounds/ # Efeitos sonoros e músicas
│ ├── Simulations/ # Scripts de simulação (SimChaves, SimDisj)
│ ├── Prefabs/ # Prefabs customizados do projeto
│ ├── Scenes/ # Cenas principais do projeto
│ └── Scripts/ # Scripts C# do jogo e da interface
└── README.md # Este arquivo
```

> **Observação:** Pastas padrão do Unity como **Standard Assets**, **TextMesh Pro**, **SampleScenes** e **QuickOutline** foram omitidas.

---

## Descrição dos Principais Diretórios

### Animation/
Animações e controladores (Animator Controllers e Animation Clips) usados para portas, chaves, atuadores e outros mecanismos no ambiente.

### Models/
Modelos 3D representando componentes elétricos, estruturas de subestação e equipamentos diversos.

### Materials/
Texturas e materiais customizados aplicados aos modelos 3D, incluindo shaders específicos e ajustes de mapeamento.

### Imagens/
Sprites e imagens de interface (UI), como ícones de painel, botões e backgrounds de menus.

### Sounds/
Efeitos sonoros de chaveamento, relés, passos e efeitos sonoros.

### Simulations/
Lógica de simulação elétrica em C#, com subpastas:
- **SimChaves/** – Simulação de circuitos e chaves.
- **SimDisj/** – Simulação de disjuntores e proteções.

### Prefabs/
Objetos pré-configurados reutilizáveis em múltiplas cenas, como painéis elétricos, botões e indicadores luminosos.

### Scenes/
Cenas principais do projeto:
- **Instrucoes.unity** – Tela de instruções e tutorial.
- **MENU.unity** – Menu inicial com opções de navegação.
- **Transformador.unity** – Ambiente de simulação de transformador.
- **Treinamento.unity** – Cenário da subestação para exercícios práticos.

### Scripts/
Scripts C# que controlam:
- Movimentação e câmeras (CameraController).
- Interações do usuário (UIManager, ButtonHandlers).

 <a name="documento"></a>

## Relatório e Apresentação do projeto
O relatório completo sobre o processo de desenvolvimento dessa aplicação pode ser encontrado em: ??. A apresentação geral do projeto pode ser encontrada em: ??.

<a name="executavel"></a>

## Executável
https://drive.google.com/drive/folders/17Sk6nZuAYeObsZY-wOQt01NrUsCHnuJa?usp=sharing
