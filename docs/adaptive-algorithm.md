# 📈 適性推薦演算法模型 (Adaptive Recommendation Algorithm)

AIPALS 平台結合 FCS1 初始能力診斷與 Rule-based 動態調整模型，精準控制題目推薦難度，達到「個人化學習（Personalized Learning）」目標。

---

## 🧮 推薦分數更新模型 ($\Delta r$)

當學生完成一次答題後，後端會呼叫 `UpdateRecommendationScore` 邏輯計算全新的推薦分數 $r$：

### 計算公式邏輯

推薦分數增減量 $\Delta r$ 依據「答題正確與否」、「題目難度係數」與「答題精準度」動態決定：

```csharp
public static double UpdateRecommendationScore(double currentScore, bool answeredCorrectly, string difficulty, double accuracy)
{
    // 邊界保護 (0.0 ~ 1.0)
    accuracy = Math.Max(0, Math.Min(1, accuracy));
    currentScore = Math.Max(0, Math.Min(1, currentScore));

    double gain = 0.05, loss = 0.03;
    switch (difficulty)
    {
        case "易": gain = 0.08; loss = 0.02; break;
        case "中": gain = 0.06; loss = 0.03; break;
        case "難": gain = 0.04; loss = 0.04; break;
    }

    double correctFactor = 0.35 + 0.65 * accuracy;
    double wrongFactor = 0.60 + 0.40 * accuracy;

    double delta = answeredCorrectly
        ? gain * correctFactor * (1 - currentScore)
        : -loss * wrongFactor * (0.5 + 0.5 * currentScore);

    return Math.Max(0, Math.Min(1, currentScore + delta));
}
