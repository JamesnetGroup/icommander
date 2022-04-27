<h1 align="center"> ICommander WPF</h1> <br>
<p align="center"><img src="Images\logo.png", width="400"></p>

<p align="center">
  <a href="https://github.com/devncore/devncore"><strong>Devncore OpenSource</strong></a>
</p>

<br />

## 목차
- [소개](#소개)
- [개발 환경](#개발-환경)
- [프로젝트 구조](#프로젝트-구조)
- [학습 가이드](#학습-가이드)
- [기능](#기능)

<br />

## 소개
> WPF 를 활용하여 MVVM 패턴으로 만든 윈도우 탐색기 입니다. 
<br />

| Star | License | Activity |
|:----:|:-------:|:--------:|
| <a href="https://github.com/devncore/icommander/stargazers"><img src="https://img.shields.io/github/stars/devncore/icommander" alt="Github Stars"></a> | <img src="https://img.shields.io/github/license/devncore/icommander" alt="License"> | <a href="https://github.com/devncore/icommander/pulse"><img src="https://img.shields.io/github/commit-activity/m/devncore/icommander" alt="Commits-per-month"></a> |

![ICommander](https://user-images.githubusercontent.com/76234292/165553573-7a372490-10d6-4a1c-b7eb-2ef7e822f4a7.png)

<br />

## 개발 환경
 
✔️ **WPF .NET Core** &nbsp; [.NET 6.0]

✔️ **Visual Studio 2022**  

✔️ **C# 10.0**  

<br/>

![11](https://user-images.githubusercontent.com/76234292/165532633-b5c90fad-6b62-4677-a638-48cff70ef398.png)

<br />

## 프로젝트 구조
> 소스코드는  **`Based`** **`Core`** **`Implements`** **`Presentation`** **`Client`** 5개의 폴더 구조로 구성되어 있습니다. <br />
 
<details open>
  <summary>
	📁 Based
  </summary>

  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.Data  
  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.WindowsBase  
  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.WindowsReference  
</details>

<details open>
  <summary>
	📁 Core
  </summary>

  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.Control  
  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.Converter  
</details>

<details open>
  <summary>
	📁 Implements
  </summary>

  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.LayoutSupport  
  &nbsp;&nbsp;&nbsp;&nbsp; - Commander.Resources  
</details>

<details open>
  <summary>
	📁 Presentation    
  </summary>
  
  &nbsp;&nbsp;&nbsp;&nbsp; - 📁 Partials    
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  - Commander.Part.Explorer  
  &nbsp;&nbsp;&nbsp;&nbsp; - 📁 Windows    
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  - Commander.Part.Main  
    
</details>

<details open>
  <summary>
	📁 Client
  </summary>

  &nbsp;&nbsp;&nbsp;&nbsp; - Commander  
</details>


### `Based`
로컬 기반에서 필요한 클래스 영역입니다. File, Window Module, Mvvm에 필요한 모듈 등 로컬에서 필요한 모든 클래스를 이 위치에서 관리합니다.

### `Core`
기본 Control 및 File Converter 등을 정의한 영역입니다. 

### `Implements`
Layout 및 Resources를 포함하는 영역입니다.

### `Presentation`
Mainwindow 창 및 ViewModel 등을 포함하는 영역입니다. 

### `Client`
프로젝트의 시작점 영역입니다.

<br />

## 학습 가이드

- WPF 프로젝트를 올바르게 구현하는 방법을 학습 합니다.
- **`윈도우탐색기`** 를 상용 컴포넌트에 의지하지 않고 WPF로만 구현 할 수 있습니다.
- MVVM 패턴을 직접 구현하여 WPF에 대해 자세하게 이해하고 학습 할 수 있습니다.
- **초보자:** WPF와 MVVM의 이해가 부족하더라도 컴포넌트의 도움 없이 소스코드를 처음부터 작성하고 완성시켜 실행시킬 수 있습니다.
- **숙련자:** C#과 WPF를 접해본 개발자라면 약 2시간 이내에 소스코드 전체를 작성 및 실행시키며 MVVM 패턴 구조의 이해를 도와줍니다.

**ICommander**를 통해 학습할 수 있는 기술들은 아래와 같습니다.
- [x] Mvvm 패턴
- [x] CustomControl
- [x] Trigger
- [x] ControlTemplate
- [x] Binding
- [x] RelayCommand
- [x] DataContext
- [x] Application
- [x] ItemsPresenter
- [x] ContentPresenter
- [x] ListBox / ListBoxItem
- [x] Transparent
- [x] Toggle 
- [x] DllImport 
- [x] ImageSource

<br />

## 기능
- 뒤로가기
- 앞으로가기
- 파일 우클릭
- 폴더생성
- Command Prompt
- CopyTab

| 우클릭 | 폴더생성 | CMD |
|:--:|:--:|:--:|
| ![우클릭](https://user-images.githubusercontent.com/76234292/165585045-7f4ab7b9-5dcd-47bc-aba5-92911909c383.png) | ![폴더생성](https://user-images.githubusercontent.com/76234292/165585062-145e1a35-3b68-4493-b3c2-b491e0850441.PNG) | ![명령프롬프트](https://user-images.githubusercontent.com/76234292/165585069-9e4a5b2b-46bc-4a26-b109-4230675c1874.PNG) |





