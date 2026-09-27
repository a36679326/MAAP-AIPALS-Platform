# 🤖 多代理 AI 工作流程 (Multi-Agent Workflow)

為了克服傳統生成式 AI 的「發散性」與「無幻覺控制（Hallucination）」，本平台將教學任務拆解為 5 個專業分工的 AI Agent，實現受控且精準的適性教學輔助。

---

## 🔄 Agent 協同工作流程圖

<img width="915" height="640" alt="image" src="https://github.com/user-attachments/assets/9fa1a2fd-54a6-4409-be93-cf274fa3a659" />
<img width="915" height="640" alt="image" src="https://github.com/user-attachments/assets/66bc5681-8228-4ce9-ad1e-fe877f340512" />

---

## 🧩 代理角色與職責

| Agent 名稱 | 核心職責 | 關鍵 Prompt 機制 / Guardrails |
| :--- | :--- | :--- |
| **Task Generation Agent** | 依據推薦難度與單元生成 Python 程式練習題 | 限定範疇、禁止使用未學套件（如 `import`）、定義標準 JSON 格式。 |
| **Review Agent** | 審查新生成的題目品質與合規性 | 實作 Self-Correction 機制，自動過濾重複題型與語法錯誤。 |
| **Evaluation Agent** | 分析學生提交的程式碼並給予客觀評估 | 比較輸出結果與邏輯結構，判定正確率與常見 Bug 類型。 |
| **Dynamic Hint Agent** | 提供引導式提示（Scaffolding Hints） | **禁止直接給出答案或正確 Code**，僅以思考方向進行蘇格拉底式引導。 |
| **Learning Analytics Agent** | 整合量化數據生成個人化學習診斷報告 | 結合 SQL 統計數據（如反應時間、答題率）生成文本摘要報告。 |
