# 📘 XTS API Client – C# (Mini Version)

## 📌 Overview
This project is a **C# mini implementation** inspired by the Python package  
https://pypi.org/project/xts-api-client/

The objective of this assignment is **not to build a full trading system**, but to:
- Understand an existing **Python SDK**
- Re-design a **minimal, clean architecture** in **C#**
- Demonstrate understanding of:
  - REST APIs
  - Token-based authentication
  - Market data handling
  - Socket-based streaming
  - Error handling & real-world API constraints

---

## 🎯 Scope of Implementation

### ✅ Implemented
- Market data **authentication flow**
- Equity **OHLC data** module (Top 5 NIFTY 50 – design ready)
- **F&O near-month 1-minute data** module (HDFCBANK, NIFTY – design ready)
- **Socket streaming** using WebSocket (mock implementation)
- Modular, extensible **SDK-style architecture**

### ❌ Out of Scope (By Design)
- Order placement
- Portfolio / positions
- Live trading
- Production-grade retries & caching

---

## 🏗️ Project Folder Structure

XTSApiClient/
│
└── XTSClient/
    │
    ├── .gitignore
    ├── README.md
    ├── Program.cs
    ├── XTSClient.csproj
    │
    ├── Core/
    │   ├── ApiClient.cs
    │   └── XtsSession.cs
    │
    ├── MarketData/
    │   ├── OhlcService.cs
    │   └── FnoService.cs
    │
    ├── Socket/
    │   └── MarketSocket.cs
    │
    ├── Models/
    │   └── LoginResponse.cs
    │
    └── appsettings.example.json   (sample config, real one NOT committed)




---

## 🧠 Architecture Design

### Core Components
- **ApiClient**
  - Base HTTP client
  - Centralized authorization handling
- **XtsSession**
  - Handles login & token lifecycle
- **MarketData Services**
  - `OhlcService` – Equity OHLC data
  - `FnoService` – F&O near-month 1-min data
- **Socket Layer**
  - WebSocket-based streaming (mock / demo)
- **Config**
  - Externalized via `appsettings.json`

---

## 🔐 Authentication Flow

1. Client sends `appKey` and `secretKey`
2. Request hits XTS **market data authentication endpoint**
3. API validates credentials
4. Token (if permitted) is returned and stored
5. Token is attached to all subsequent REST calls

---

## ⚠️ Important Authentication Note (CTCL Restriction)

```json
{
  "type": "error",
  "code": "e-response-0012",
  "description": "This application is only enabled for CTCL"
}

🚀 How to Run

dotnet clean
dotnet build
dotnet run

