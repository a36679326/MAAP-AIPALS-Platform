# 🤖 多代理 AI 工作流程 (Multi-Agent Workflow)

為了克服傳統生成式 AI 的發散性與無幻覺控制（Hallucination），AIPALS 平台將教學互動任務精準拆解為**雙階段（Two-Phase）Multi-Agent 工作流程**，實現受控且精準的適性教學輔助[cite: 14, 15]。

---

## 🔄 雙階段代理工作流程

### 階段一：Task Generation & Review Phase（出題與審核流程）

負責根據學習者需求派發或即時生成符合難度的題目。

<img width="915" height="640" alt="image" src="https://github.com/user-attachments/assets/9fa1a2fd-54a6-4409-be93-cf274fa3a659" />

---

### 階段二：Evaluation, Hint & Feedback Phase（作答、評估與反饋流程）

負責處理學習者作答過程中的動態提示（Dynamic Hint）、作答結果評估（Evaluation）與學習歷程更新。

<img width="915" height="640" alt="image" src="https://github.com/user-attachments/assets/66bc5681-8228-4ce9-ad1e-fe877f340512" />

---

## 🧩 代理角色與職責

| Agent 名稱 | 所屬階段 | 核心職責 | 關鍵 Prompt 機制 / Guardrails |
| :--- | :--- | :--- | :--- |
| **Task Generation Agent** | 階段一[cite: 14] | 依據推薦難度與單元生成 Python 練習題[cite: 14] | 限定範疇、禁止使用未學套件（如 `import`）、定義標準 JSON 格式。 |
| **Review Agent** | 階段一[cite: 14] | 審查新生成的題目品質與合規性[cite: 14] | 實作 Self-Correction 機制，自動過濾重複題型與語法錯誤。 |
| **Dynamic Hint Agent** | 階段二[cite: 15] | 提供引導式提示（Scaffolding Hints）[cite: 15] | **禁止直接給出答案或正確 Code**，僅以思考方向進行蘇格拉底式引導。 |
| **Evaluation Agent** | 階段二[cite: 15] | 分析學生提交的程式碼並給予客觀評估[cite: 15] | 比較輸出結果與邏輯結構，判定正確率與常見 Bug 類型。 |
| **Learning Analytics Agent** | 階段二[cite: 15] | 整合量化數據並更新學習者 Profiles[cite: 15] | 結合 SQL 統計數據（如反應時間、答題率）更新 DB 與生成文字分析報告。 |
