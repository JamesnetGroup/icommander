# ICommander  [![英文](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![中文](https://img.shields.io/badge/Language-中文-red.svg)](README.zh-CN.md) [![韩文](https://img.shields.io/badge/Language-한국어-green.svg)](README.ko.md)

基于 WPF 的 Windows 内置资源管理器应用程序，实现了 MVVM 模式
[![许可证: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![星标](https://img.shields.io/github/stars/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/stargazers)
[![问题](https://img.shields.io/github/issues/jamesnet214/icommander.svg)](https://github.com/jamesnet214/icommander/issues)

## 项目概述

ICommander 是一个基于 WPF 的应用程序，在自定义窗口中复制了 Windows 资源管理器的功能。该项目是在实际应用中实现 MVVM 模式的优秀示例，为开发人员提供了高级 WPF 技术和适当项目结构的见解。

<img src="https://github.com/user-attachments/assets/49d7f1eb-ea7c-4455-9ade-70fec6f2ab48" width="49%"/>
<img src="https://github.com/user-attachments/assets/3912439e-7288-4b16-8b0d-d30d2b4b3823" width="49%"/>

## 主要技术和实现

#### 1. MVVM 架构
- [x] 完全实现 MVVM 模式
- [x] 适当使用 DataContext 和 Binding
- [x] 实现 RelayCommand 用于动作绑定

#### 2. 自定义控件和模板
- [x] 开发自定义控件用于表示文件和文件夹
- [x] 高级使用 ControlTemplate 和 DataTemplate
- [x] 实现 Trigger 用于动态 UI 更新

#### 3. 文件系统集成
- [x] 使用 DllImport 集成 Windows 文件系统
- [x] 实现文件和文件夹操作（创建、删除、重命名）
- [x] 文件和文件夹导航，支持前进和后退

#### 4. UI/UX 设计
- [x] 实现类似 Windows 资源管理器的界面
- [x] 实现上下文菜单用于文件和文件夹操作
- [x] 基于标签的界面，用于多文件夹视图

#### 5. 性能优化
- [x] 高效加载和显示文件系统内容
- [x] 流畅的导航和操作处理

## 技术栈
- .NET 8.0
- WPF (Windows Presentation Foundation)
- C# 10.0
- MVVM (Model-View-ViewModel) 模式

## 入门指南

### 先决条件
- Visual Studio 2022 或更高版本
- .NET 8.0 SDK

### 安装和运行

#### 1. 克隆仓库：
```
git clone https://github.com/jamesnet214/icommander.git
```

#### 2. 打开解决方案
- [x] Visual Studio
- [x] Visual Studio Code
- [x] Jetbrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. 构建和运行
- [x] 推荐 Windows 11

## 使用方法
1. 运行 ICommander 应用程序
2. 使用类似资源管理器的界面浏览文件系统
3. 使用上下文菜单进行文件和文件夹操作
4. 利用命令提示符功能进行高级操作

## 项目结构

项目由五个主要文件夹组成：
- **Based**: 包含核心类，用于文件操作、窗口模块和 MVVM 基础
- **Core**: 定义基本控件和文件转换器
- **Implements**: 包含布局和资源
- **Presentation**: 包含主窗口和视图模型
- **Client**: 应用程序的入口点

## 贡献

如果您想为项目改进做出贡献，请发送 Pull Request。我们欢迎任何形式的贡献！

## 许可证

本项目基于 MIT 许可证发布。详情请参阅 [LICENSE](https://github.com/jamesnet214/icommander/blob/main/LICENSE) 文件。

## 联系方式
- 网站：https://jamesnet.dev
- 电子邮件：james@jamesnet.dev, vickyqu115@hotmail.com

使用 ICommander 探索高级 WPF 技术和 MVVM 实现！
