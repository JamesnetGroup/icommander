# ICommander [![English](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![한국어](https://img.shields.io/badge/Language-한국어-red.svg)](README.ko.md)

A WPF-based in-window explorer application implementing MVVM pattern

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Stars](https://img.shields.io/github/stars/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/stargazers)
[![Issues](https://img.shields.io/github/issues/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/issues)

## Project Overview
ICommander is a WPF-based application that replicates the functionality of Windows Explorer within a custom window. This project serves as an excellent example of implementing MVVM pattern in a real-world application, providing developers with insights into advanced WPF techniques and proper project structuring.

<img src="https://github.com/user-attachments/assets/49d7f1eb-ea7c-4455-9ade-70fec6f2ab48" width="49%"/>
<img src="https://github.com/user-attachments/assets/3912439e-7288-4b16-8b0d-d30d2b4b3823" width="49%"/>

## Key Technologies and Implementations
#### 1. MVVM Architecture
- [x] Full implementation of MVVM pattern
- [x] Proper use of DataContext and Binding
- [x] Implementation of RelayCommand for action binding

#### 2. Custom Controls and Templates
- [x] Development of custom controls for file and folder representation
- [x] Advanced usage of ControlTemplate and DataTemplate
- [x] Implementation of Triggers for dynamic UI updates

#### 3. File System Integration
- [x] Integration with Windows file system using DllImport
- [x] Implementation of file and folder operations (create, delete, rename)
- [x] File and folder browsing with back and forward navigation

#### 4. UI/UX Design
- [x] Creation of a Windows Explorer-like interface
- [x] Implementation of context menus for file and folder operations
- [x] Tab-based interface for multiple folder views

#### 5. Performance Optimization
- [x] Efficient loading and display of file system contents
- [x] Smooth navigation and operation handling

## Technology Stack
- .NET 8.0
- WPF (Windows Presentation Foundation)
- C# 10.0
- MVVM (Model-View-ViewModel) pattern

## Getting Started
### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK

### Installation and Execution
#### 1. Clone the repository:

```
git clone https://github.com/jamesnet214/icommander.git
```

#### 2. Open the solution
- [x] Visual Studio
- [x] Visual Studio Code
- [x] Jetbrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. Build and Run
- [x] Windows 11 recommended

## Usage
1. Launch the ICommander application
2. Navigate through your file system using the explorer-like interface
3. Use context menus for file and folder operations
4. Utilize the command prompt feature for advanced operations

## Project Structure
The project is organized into five main folders:
- **Based**: Contains core classes for file operations, window modules, and MVVM basics
- **Core**: Defines basic controls and file converters
- **Implements**: Includes layouts and resources
- **Presentation**: Contains the main window and view models
- **Client**: Entry point of the application

## Contributing
If you'd like to contribute to improving the project, please send a Pull Request. All forms of contribution are welcome!

## License
This project is distributed under the MIT license. For more details, please refer to the [LICENSE](https://github.com/jamesnet214/icommander/blob/main/LICENSE) file.

## Contact
- Website: https://jamesnet.dev
- Email: james@jamesnet.dev, vickyqu115@hotmail.com

Explore advanced WPF techniques and MVVM implementation with ICommander!
