# ICommander [![English](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![한국어](https://img.shields.io/badge/Language-한국어-red.svg)](README.ko.md)
MVVM 패턴을 구현한 WPF 기반의 윈도우 내 탐색기 애플리케이션
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Stars](https://img.shields.io/github/stars/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/stargazers)
[![Issues](https://img.shields.io/github/issues/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/issues)

## 프로젝트 개요
ICommander는 사용자 정의 창 내에서 Windows 탐색기의 기능을 복제한 WPF 기반 애플리케이션입니다. 이 프로젝트는 실제 애플리케이션에서 MVVM 패턴을 구현하는 우수한 예시로, 개발자들에게 고급 WPF 기술과 적절한 프로젝트 구조화에 대한 통찰을 제공합니다.

<img src="https://github.com/user-attachments/assets/49d7f1eb-ea7c-4455-9ade-70fec6f2ab48" width="49%"/>
<img src="https://github.com/user-attachments/assets/3912439e-7288-4b16-8b0d-d30d2b4b3823" width="49%"/>

## 주요 기술 및 구현 사항
#### 1. MVVM 아키텍처
- [x] MVVM 패턴의 완전한 구현
- [x] DataContext와 Binding의 적절한 사용
- [x] 액션 바인딩을 위한 RelayCommand 구현

#### 2. 커스텀 컨트롤 및 템플릿
- [x] 파일 및 폴더 표현을 위한 커스텀 컨트롤 개발
- [x] ControlTemplate 및 DataTemplate의 고급 사용
- [x] 동적 UI 업데이트를 위한 Trigger 구현

#### 3. 파일 시스템 통합
- [x] DllImport를 사용한 Windows 파일 시스템 통합
- [x] 파일 및 폴더 작업 구현 (생성, 삭제, 이름 변경)
- [x] 뒤로 가기 및 앞으로 가기 탐색이 가능한 파일 및 폴더 탐색

#### 4. UI/UX 디자인
- [x] Windows 탐색기와 유사한 인터페이스 구현
- [x] 파일 및 폴더 작업을 위한 컨텍스트 메뉴 구현
- [x] 여러 폴더 뷰를 위한 탭 기반 인터페이스

#### 5. 성능 최적화
- [x] 파일 시스템 콘텐츠의 효율적인 로딩 및 표시
- [x] 부드러운 탐색 및 작업 처리

## 기술 스택
- .NET 8.0
- WPF (Windows Presentation Foundation)
- C# 10.0
- MVVM (Model-View-ViewModel) 패턴

## 시작하기
### 필요 조건
- Visual Studio 2022 이상
- .NET 8.0 SDK

### 설치 및 실행
#### 1. 리포지토리 클론:

```
git clone https://github.com/jamesnet214/icommander.git
```

#### 2. 솔루션 열기
- [x] Visual Studio
- [x] Visual Studio Code
- [x] Jetbrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. 빌드 및 실행
- [x] Windows 11 권장

## 사용 방법
1. ICommander 애플리케이션 실행
2. 탐색기와 유사한 인터페이스를 사용하여 파일 시스템 탐색
3. 파일 및 폴더 작업을 위해 컨텍스트 메뉴 사용
4. 고급 작업을 위한 명령 프롬프트 기능 활용

## 프로젝트 구조
프로젝트는 다섯 개의 주요 폴더로 구성되어 있습니다:
- **Based**: 파일 작업, 창 모듈, MVVM 기본 사항을 위한 핵심 클래스 포함
- **Core**: 기본 컨트롤 및 파일 변환기 정의
- **Implements**: 레이아웃 및 리소스 포함
- **Presentation**: 메인 창 및 뷰 모델 포함
- **Client**: 애플리케이션의 진입점

## 기여하기
프로젝트 개선에 기여하고 싶으시다면 Pull Request를 보내주세요. 모든 형태의 기여를 환영합니다!

## 라이선스
이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](https://github.com/jamesnet214/icommander/blob/main/LICENSE) 파일을 참조하세요.

## 연락처
- 웹사이트: https://jamesnet.dev
- 이메일: james@jamesnet.dev, vickyqu115@hotmail.com

ICommander로 고급 WPF 기술과 MVVM 구현을 탐험해보세요!
