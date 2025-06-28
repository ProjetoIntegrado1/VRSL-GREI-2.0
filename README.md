# VRSL-GREI-2.0

## Membros
**Antônio Lucas Vieira de Lima** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**Henrique Segundo da Fonseca** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**João Amauri Rodrigues do Nascimento** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**John Lennon Fernandes de Andrade** (Bacharelando em Sistemas e Mídias Digitais, UFC)   
**Luana Moreira Dias** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**Luis Henrique da Costa Silva** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
  

## Requisitos

| ID      | Title                                          | Description                                                                                                                                                                                                                                                                  | Priority | Status      | Arquivo / Implementação                                                                                                                                                         |
| ------- | ------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------- | --------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| VSRF 01 | Mudar de área                                  | **COMO** usuário, **QUERO** alternar entre os diferentes mapas do simulador de forma rápida. **PARA** que a aula ou minha atividade de casa prossiga de forma fluída.                                                                                                        | High     | Done        | 📄 [**FirstPersonController.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/FirstPersonController.cs) e 📄 [**GameManager.cs**](Assets/Scripts/GameManager.cs) - O método Warp() é definido no FirstPersonController.cs e muda a posição e rotação do jogador conforme entregado ao método, o GameManager.cs tem os métodos de mudar de cena em conjunto com os teleporte com as posições e rotações adequadas, que são chamadas nos botões de teleporte implementados na HUD. Se estiver fora da cena alvo ele muda para a cena alvo. |
| VSRF 02 | Visualizar Diagramas                           | **COMO** usuário, **QUERO** visualizar os diferentes diagramas que são utilizados em uma subestação. **PARA** conseguir demonstrar os conteúdos vistos em cadeiras anteriores sendo utilizados em prática com componentes “reais”.                                           | High     | In progress |  —                                                    |
| VSRF 03 | Visualizar Missões/Objetivos                   | **COMO** usuário, **QUERO** visualizar meus próximos passos para o andamento da aula e/ou atividade de forma que possua um roteiro coeso. **PARA** não ficar perdido e ter meu aprendizado possivelmente prejudicado.                                                        | High     | To do       | —                                                                                                                                                                               |
| VSRF 04 | Selecionar roteiro                             | **COMO** usuário, **QUERO** selecionar qual conjunto de missões/atividades irei realizar para as atividades que irei realizar em sala ou em casa. **PARA** manter uma linha de aprendizado que não me deixe confuso quanto a onde estou e o que estou fazendo na subestação. | Low      | To do       | —                                                                                                                                                                               |
| VSRF 05 | Iniciar o jogo                                 | **COMO** usuário, **QUERO** um menu inicial amigável e intuitivo que permita a manipulação por um único operador. **PARA** que como professor, não necessite de um terceiro para auxiliar com o simulador durante a aula.                                                    | High     | In Progress |  —                                                          |
| VSRF 06 | Visualizar Informações                         | **COMO** usuário, **QUERO** visualizar informações sobre componentes presentes na subestação. **PARA** aprender mais sobre como aqueles componentes funcionam e auxiliam no funcionamento da subestação.                                                                     | Medium   | In Progess      |  —                    |
| VSRF 07 | Navegar de forma fluida                        | **COMO** usuário, **QUERO** utilizar o programa sem travamentos e/ou quedas de FPS em minha máquina. **PARA** conseguir utilizar o simulador em máquinas que não sejam potentes, como as da minha casa.                                                                      | Low      | To do       | —                                                                                                                                                                               |
| VSRF 08 | Alternar rapidamente entre pontos de interesse | **COMO** usuário, **QUERO** visitar rapidamente locais da subestação. **PARA** minimizar o tempo que posso acabar perdendo, seja em sala de aula ou em casa, navegando de um ponto a outro da subestação.                                                                    | Medium   | Done        | 📄 [**FirstPersonController.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/FirstPersonController.cs) e 📄 [**GameManager.cs**](Assets/Scripts/GameManager.cs) - O método Warp() é definido no FirstPersonController.cs e muda a posição e rotação do jogador conforme entregado ao método, o GameManager.cs tem os métodos de mudar de cena em conjunto com os teleporte com as posições e rotações adequadas, que são chamadas nos botões de teleporte implementados na HUD. Se estiver dentro da cena alvo ele muda a posição e rotação do jogador. |
| VSRF 09 | Surgir no mapa                                 | **COMO** usuário, **QUERO** adentrar no ambiente 3D de modo a visualizar os principais pontos de interesse. **PARA** já na primeira observação, conseguir ver os pontos principais da subestação.                                                                            | High     | Done        |  |
| VSRF 10 | Visualizar Controles                           | **COMO** usuário, **QUERO** visualizar o esquema de botões utilizado no simulador de forma objetiva e simples. **PARA** não ficar perdido e/ou confuso durante a navegação na subestação.                                                                                    | High     | In progress |  —                                               |
| VSRF 11 | Movimentar pelo mapa                           | **COMO** usuário, **QUERO** que o esquema de botões seja o mais simples possível e ao mesmo tempo intuitivo para que consiga andar pelo mapa sem problemas. **PARA** que, mesmo não sendo tão letrado digitalmente, consiga utilizar o simulador de forma satisfatória.      | Low      | In Progress |  —                                         |
| VSRF 12 | Soltar mouse durante a mira                    | **COMO** usuário, **QUERO** soltar o mouse durante a mira para apertar nos botões da HUD. **PARA** interagir com a interface e não precisar usar os atalhos de teclado.                                                                                                      | High     | Done        |  —                                      |
| VSRF 13 | Hover em objetos interagíveis                  | **COMO** usuário, **QUERO** que os objetos interagíveis possuam um efeito de hover outline. **PARA** identificar visualmente o que pode ser interagido na cena.                                                                                                              | High     | Done        | 📄 [**HoverOutline.cs**](Assets/Scripts/HoverOutline.cs) |
| VSRF 14 | Mostrar todos objetos interativos              | **COMO** usuário, **QUERO** apertar um botão para mostrar todos os objetos interagíveis da cena. **PARA** ter uma visão geral rápida dos pontos disponíveis para interação.                                                                                                  | Medium   | Done        | 📄 [**MenuSystem.cs**](Assets/Scripts/MenuSystem.cs): implementado `ToggleAllOutlines()` que varre `FindObjectsOfType<Outline>()` e inverte `enabled`                                                              |

## BugFix

| ID      | Title                      | Description                                                                                                                                                    | Priority | Status      | Arquivo / Implementação                                                                                                       |
| ------- | -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- | ----------- | ----------------------------------------------------------------------------------------------------------------------------- |
| VSBF 01 | Menus sobrepostos          | **COMO** usuário, **QUERO** que os menus não se sobreponham entre si. **PARA** evitar confusão e conflitos com o sistema de movimentação.                      | High     | Done        |  —                |
| VSBF 02 | Caixa de seleção de Botões | **COMO** usuário, **QUERO** que a área de clique dos botões no menu inicial tenha o tamanho adequado. **PARA** não acionar o botão ao clicar fora de sua área. | High     | In progress |  —                |
| VSBF 03 | Desativar interação com hover durante menus | **COMO** usuário, **QUERO** que a interação por hover em objetos não funcione enquanto qualquer menu estiver aberto. **PARA** evitar cliques e contornos indesejados sobre interfaces de menu. | Medium   | Done        |  —  |
| VSBF 04 | Acelerar abertura de portas                 | **COMO** usuário, **QUERO** que as portas abram mais rápido ao interagir. **PARA** manter o fluxo da experiência de forma dinâmica.                                                            | Low      | Done        |  —  |
| VSBF 05 | Corrigir colisão em mapa do transformador   | **COMO** usuário, **QUERO** evitar bugar a colisão no mapa do transformador para não cair fora dos limites da cena. **PARA** garantir navegação segura e sem travamentos.                      | Low      | Done        |  —  |
| VSBF 06 | Limitar rotação vertical   | **COMO** usuário, **QUERO** limitar a rotação da câmera a 90° para cima e 90° para baixo. **PARA** evitar giros completos de 360° desorientadores.                          | Low      | Done        | 📄 [**MouseLook.cs**](Assets/Standard%20Assets/Characters/FirstPersonCharacter/Scripts/MouseLook.cs): refatorado para usar variável de pitch com `Mathf.Clamp(MinimumX, MaximumX)`                                              |
| VSBF 07 | Movimentação precisa       | **COMO** usuário, **QUERO** que o personagem ande precisamente na direção pressionada sem inclinação lateral. **PARA** melhorar o controle e evitar movimentos indesejados. | Low      | Done        |   —   |



## Sobre  
VRSL é um simulador de subestações de energia, baseado na subestação da Universidade Federal do Ceará (UFC), sendo utilizado em sala de aula principalmente para a cadeira de Geração, Distribuição e Transmissão do curso de Engenharia Elétrica da UFC.
Ele foi originalmente desenvolvido pelo Grupo de Redes Elétricas Inteligentes (GREI).
## Tecnologias 
### Unity Engine e C#
<img align="center" alt="Rafa-Unity" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/unity/unity-original.svg">  <img align="center" alt="Rafa-Csharp" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">

## Guia de Instalação

Siga os passos abaixo para configurar e executar este projeto Unity corretamente no seu computador.

### 1. Baixar e Instalar o Unity Hub e o Unity Editor

1. Acesse: [https://unity.com/download](https://unity.com/download)
2. Faça o download do Unity Hub para o seu sistema operacional.
3. No Unity Hub, instale a versão **2022.3.32f1** do Unity Editor.

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

## Executável teste
https://drive.google.com/drive/folders/17Sk6nZuAYeObsZY-wOQt01NrUsCHnuJa?usp=sharing
