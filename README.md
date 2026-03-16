# EyeCameraStreamer

**Bigscreen Beyond 2e (BSB2e) のカメラ映像を EyeTrackVR へ繋ぐブリッジツール**

---

## 📝 概要
Bigscreen Beyond 2e に搭載されているアイトラッキング用カメラ映像を、**EyeTrackVR** で扱える形式に変換・配信するためのソフトウェアです。

BSB2eのカメラ映像はそのままでは EyeTrackVR で直接取り込むことができません。本ソフトを経由して「左目用・右目用」の2つのストリームに分割・HTTP配信することで、EyeTrackVR でのアイトラッキングを可能にします。

## ✨ 特徴

### 🔗 BSB2e ↔ EyeTrackVR の架け橋
* 1つのカメラデバイスから取得した映像を左右に分割し、EyeTrackVR が読み取れる2系統の HTTP MJPEG ストリームとして配信します。

### ⚡ 究極の低負荷設計
* VR体験を邪魔しないよう、バックグラウンド実行時やプレビュー非表示時は処理を最小限に抑え、CPU使用率を極限まで低減しています。

### 🌓 最適な画像補正 (CLAHE)
* 赤外線カメラ映像にリアルタイムでコントラスト補正をかけ、瞳孔の認識精度を向上させます。

### 🔄 自動再接続（オートヒーリング）
* カメラのケーブルが抜けても大丈夫。挿し直せば自動的に検知し、配信を即座に再開します。

### 🚀 EyeTrackVR 連携
* 本ソフトから EyeTrackVR 本体を自動起動する連携機能を搭載しています。

### ⚡️ ゼロクリック・セットアップ
* 一度設定を済ませれば、次回からはアプリを起動するだけで以下のすべてを自動で完結させます。
    1. **カメラ配信の自動開始**: 前回保存した設定で、即座にキャプチャとストリーミングを開始します。
    2. **EyeTrackVR の自動起動**: 連携アプリを探して立ち上げる手間を省きます。

## 🚀 使い方

1. **EyeCameraStreamer** を起動します。
2. BSB2e のカメラデバイスを選択し、左右の配信ポート（例: `8080` / `8081`）を設定します。
3. **Start** をクリックして配信を開始します。
4. **EyeTrackVR** 側の設定（Camera Address）に以下のURLを入力してください。
    * **左目**: `http://localhost:8080`
    * **右目**: `http://localhost:8081`

## 📦 インストール / 実行
* **インストール不要**: `EyeCameraStreamer.exe` を実行するだけで使用可能です。
* **動作環境**: Windows 11 (x64)

---

## 📝 Overview
**EyeCameraStreamer** is a lightweight utility designed to convert and stream eye-tracking camera feeds from the **Bigscreen Beyond 2e (BSB2e)** into a format compatible with **EyeTrackVR**.

Since BSB2e camera feeds cannot be directly imported into EyeTrackVR, this tool splits the single camera feed into two separate "Left Eye" and "Right Eye" HTTP MJPEG streams, enabling seamless eye tracking.

## ✨ Features

### 🔗 The Bridge: BSB2e ↔ EyeTrackVR
* Captures a single camera device and splits the video into two independent HTTP MJPEG streams that EyeTrackVR can process.

### ⚡ Ultra-Low CPU Usage
* Optimized for VR performance. Processing is minimized when running in the background or when the preview is hidden to ensure zero impact on your VR experience.

### 🌓 Optimized Image Enhancement (CLAHE)
* Applies real-time Contrast Limited Adaptive Histogram Equalization (CLAHE) to infrared feeds, significantly improving pupil recognition accuracy.

### 🔄 Auto-Reconnect (Auto-Healing)
* Robust connection management. If a camera cable is unplugged, the tool automatically detects and resumes streaming as soon as it's reconnected.

### 🚀 EyeTrackVR Integration
* Features a built-in launcher to automatically start the EyeTrackVR application alongside the streamer.

### ⚡️ Zero-Click Setup
* Once configured, simply launch the app to automate everything:
    1. **Auto-Start Streaming**: Immediately begins capturing and streaming using your last saved settings.
    2. **Auto-Launch EyeTrackVR**: Starts the EyeTrackVR app, saving you the hassle of manual setup every time.

## 🚀 How to Use

1. Launch **EyeCameraStreamer**.
2. Select the BSB2e camera device and set the desired ports for each eye (e.g., `8080` / `8081`).
3. Click **Start** to begin streaming.
4. In the **EyeTrackVR** settings (Camera Address), enter the following URLs:
    * **Left Eye**: `http://localhost:8080`
    * **Right Eye**: `http://localhost:8081`

## 📦 Installation / Execution
* **Portable**: No installation required. Just run `EyeCameraStreamer.exe`.
* **System Requirements**: Windows 11 (x64)

---
