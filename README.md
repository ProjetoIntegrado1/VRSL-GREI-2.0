# VRSL-GREI-2.0

## Membros
**Antônio Lucas Vieira de Lima** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**John Lennon Fernandes de Andrade** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**Luana Moreira Dias** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**Henrique Segundo da Fonseca** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**Luis Henrique da Costa Silva** (Bacharelando em Sistemas e Mídias Digitais, UFC)  
**João Amauri Rodrigues do Nascimento** (Bacharelando em Sistemas e Mídias Digitais, UFC)  

## Requisitos
| ID | Title | Description | Priority |
| -- | ----- | ------------ | -------- |
| VSRF 01 | Mudar de área | **COMO** usuário, **QUERO** alternar entre os diferentes mapas do simulador de forma rápida. **PARA** que a aula ou minha atividade de casa prossiga de forma fluída. | High | 
| VSRF 02 | Visualizar Diagramas | **COMO** usuário, **QUERO** visualizar os diferentes diagramas que são utilizados em uma subestação. **PARA** conseguir demonstrar os conteúdos vistos em cadeiras anteriores sendo utilizados em prática com componentes “reais”. | High |
| VSRF 03 | Visualizar Missões/Objetivos | **COMO** usuário, **QUERO** visualizar meus próximos passos para o andamento da aula e/ou atividade de forma que possua um roteiro coeso. **PARA** não ficar perdido e ter meu aprendizado possivelmente prejudicado. | High |
| VSRF 04 | Selecionar roteiro | **COMO** usuário, **QUERO** selecionar qual conjunto de missões/atividades irei realizar para as atividades que irei realizar em sala ou em casa. **PARA** manter uma linha de aprendizado que não me deixe confuso quanto a onde estou e o que estou fazendo na subestação. | Low |
| VSRF 05 | Iniciar o jogo | **COMO** usuário, **QUERO** um menu inicial amigável e intuitivo que permita a manipulação por um único operador. **PARA** que como professor, não necessite de um terceiro para auxiliar com o simulador durante a aula. | High |
| VSRF 06 | Visualizar Informações | **COMO** usuário, **QUERO** visualizar informações sobre componentes presentes na subestação. **PARA** aprender mais sobre como aqueles componentes funcionam e auxiliam no funcionamento da subestação. | Medium |
| VSRF 07 | Navegar de forma fluida | **COMO** usuário, **QUERO** utilizar o programa sem travamentos e/ou quedas de FPS em minha máquina. **PARA** conseguir utilizar o simulador em máquinas que não sejam potentes, como as da minha casa. | Low |
| VSRF 08 | Alternar rapidamente entre pontos de interesse | **COMO** usuário, **QUERO** visitar rapidamente locais da subestação. **PARA** minimizar o tempo que posso acabar perdendo, seja em sala de aula ou em casa, navegando de um ponto a outro da subestação.  | Medium |
| VSRF 09 | Surgir no mapa | **COMO** usuário, **QUERO** adentrar no ambiente 3D de modo a visualizar os principais pontos de interesse. **PARA** já na primeira observação, conseguir ver os pontos principais da subestação. | High |
| VSRF 10 | Visualizar Controles | **COMO** usuário, **QUERO** visualizar o esquema de botões utilizado no simulador de forma objetiva e simples. **PARA** não ficar perdido e/ou confuso durante a navegação na subestação. | High |
| VSRF 11 | Movimentar pelo mapa | **COMO** usuário, **QUERO** que o esquema de botões seja o mais simples possível e ao mesmo tempo intuitivo para que consiga andar pelo mapa sem problemas. **PARA** que, mesmo não sendo tão letrado digitalmente, consiga utilizar o simulador de forma satisfatória. | Low |

## BugFix
| ID | Title | Description | Priority |
| -- | ----- | ------------ | -------- |
| VSBF 01 | Menus sobrepostos | Durante a navegação somos capazes de sobrepor menus aos outros, o que pode causar confusão, pois há conflito com o sistema de movimentação. | High |
| VSBF 02 | Caixa de seleçõo de Botões | No menu inicial, a caixa de seleção dos botões é maior do que deveria ser. Então, mesmo que o usuário clique fora dela, ele é capaz de selecionar o botão. | High |

## Sobre  
VRSL é um simulador de subestações de energia, baseado na subestação da Universidade Federal do Ceará (UFC), sendo utilizado em sala de aula principalmente para a cadeira de Geração, Distribuição e Transmissão do curso de Engenharia Elétrica da UFC.
Ele foi originalmente desenvolvido pelo Grupo de Redes Elétricas Inteligentes (GREI).
## Tecnologias 
### Unity Engine e C#
<img align="center" alt="Rafa-Unity" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/unity/unity-original.svg">  <img align="center" alt="Rafa-Csharp" height="60" width="80" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">

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
