```markdown
# 🗄️ 資料庫架構與數據設計 (Database Design & ER Schema)

本專案使用 **MS SQL Server** 搭配 **Entity Framework Core (Database-First)** 進行數據持久化，嚴格紀錄學生完整的學習閉環歷程。

---

## 📋 核心 Entity 關係說明

+------------------+         1:N          +----------------------------+
|  StudentProfiles | ───────────────────► |    StudentSubmissions      |
|  (學生基本資料)   |                      |  (答題與 AI 評分歷史紀錄)   |
+------------------+                      +----------------------------+
│                                              │
│ 1:N                                          │ N:1
▼                                              ▼
+------------------+                      +----------------------------+
| StudentProgress  |                      |       QuestionTasks        |
|  (各單元掌握度)   |                      |       (系統題庫資料)       |
+------------------+                      +----------------------------+

---

## 🔍 主要資料表結構

### 1. `StudentSubmissions` (學生作答與評分紀錄表)
* **`SubmissionId`** (PK, int): 作答紀錄識別碼
* **`StudentId`** (FK, nvarchar): 學生學號/帳號
* **`QuestionTaskId`** (FK, int): 對應題目 ID
* **`CodeSubmitted`** (nvarchar(max)): 學生提交的 Python 程式碼
* **`Score`** (float): 程式碼評分結果 (0 - 100)
* **`ResponseTimeSec`** (int): 作答耗時（秒）
* **`IsRecommended`** (bit): 是否為適性系統主動推薦題目
* **`SubmissionTime`** (datetime): 提交時間戳記

### 2. `StudentProgress` (能力掌握度與雷達圖數據表)
* **`ProgressId`** (PK, int): 紀錄識別碼
* **`StudentId`** (FK, nvarchar): 學生 ID
* **`UnitCategory`** (nvarchar): 知識單元名稱（如：輸入輸出、條件判斷、迴圈、串列）
* **`MasteryLevel`** (float): 該單元掌握度評分 (用於前台雷達圖繪製)
* **`LastUpdated`** (datetime): 最後更新時間
