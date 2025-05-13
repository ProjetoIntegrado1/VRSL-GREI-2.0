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
| VSRF 01 | Mudança de área | Como usuário, desejo alternar entre os diferentes mapas do simulador de forma rápida. | High | 
| VSRF 02 | Visualizar Diagramas | Como usuário, desejo visualizar os diferentes diagramas que são utilizados em uma subsestação. | High |
| VSRF 03 | Missões/Objetivos | Como usuário, gostaria de visualizar meus próximos passos para o andamento da aula e/ou atividade de forma que possua um roteiro coeso. | High |
| VSRF 04 | Selecionar roteiro | Como usuário, gostaria de selecionar qual conjunto de missões/atividades irei realizar para as atividades que irei realizar em sala ou em casa. | Low |
| VSRF 05 | Menu Inicial | Como usuário, gostaria de um menu inicial amigável e intuitivo que permita a manipulação por um único operador | High |
| VSRF 06 | Visualizar Informações | Como usuário, gostaria de visualizar informações sobre componentes presentes na subsestação. | Medium |
| VSRF 07 | Otimização de Modelos 3D | Como usuário, gostaria que conseguisse utilizar o programa sem travamentos e/ou quedas de FPS em minha máquina. | Low |
| VSRF 08 | Alternar rapidamente entre pontos de interesse | Como usuário, gostaria visitar rapidamente locais da subestação.  | Medium |
| VSRF 09 | Ponto de Início | Como usuário, gostaria de adentrar no ambiente 3D de modo a visualizar os principais pontos de interesse. | High |
| VSRF 10 | Visualizar Controles | Como usuário, gostaria de visualizar o esquema de botões utilizado no simulador de forma objetiva e simples. | High |
| VSRF 11 | Controles | Como usuário, gostaria que o esquema de botões fosse o mais simples possível e ao mesmo tempo intuitivo. | Low |

## Sobre  
VRSL é um simualdor de subestações de energia, baseado na subestação da Universidade Federal do Ceará (UFC), sendo utilizado em sala de aula principalmente para a cadeira de Geração, Distribuição e Transmissão do curso de Engenharia Elétrica da UFC.
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
└── README.md
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
