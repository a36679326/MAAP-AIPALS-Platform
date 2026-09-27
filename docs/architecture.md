# 🏛️ 四層式系統架構設計 (Four-Layered Architecture)

AIPALS (MAAP) 平台採用高內聚、低耦合的四層式架構設計，確保系統在處理高頻率的 AI 請求、演算法運算與資料庫讀寫時，具備優異的可維護性與擴充性。

---

## 📐 系統層級與職責分工
### 1. Presentation Layer (展示層)
* **技術棧**：ASP.NET MVC View (Razor Engine)
* **核心職責**：
  * 提供線上程式碼編輯介面（Web IDE）。
  * 展示即時 AI 引導提示（Dynamic Hint Modal）。
  * 渲染學習成效分析儀表板（雷達圖、歷史歷程折線圖）。

### 2. Application Layer (應用層)
* **技術棧**：C# Services & Controllers
* **核心職責**：
  * 處理使用者身分驗證與權限控管。
  * 執行 Rule-based 適性推薦演算法（FCS1 能力診斷與 $\Delta r$ 推薦分算）。
  * 協調 AI Service 與 Data Layer 之間的資料傳遞。

### 3. AI Service Layer (AI 服務層)
* **技術棧**：C# HttpClient / RESTful API / OpenAI Assistant API v2
* **核心職責**：
  * 管理 Multi-Agent 工作流程（生題、審題、評估、提示）。
  * 封裝系統層級 Prompt Guardrails（提示詞邊界控制）。
  * 處理 JSON 格式解析與例外容錯機制。

### 4. Data Layer (資料層)
* **技術棧**：MS SQL Server / Entity Framework Core (Database-First)
* **核心職責**：
  * 持久化保存學生作答歷程、代碼提交紀錄與評分結果。
  * 聚合分析歷史數據以提供學習能力分析雷達圖資料。
