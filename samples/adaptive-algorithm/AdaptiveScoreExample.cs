using System;

namespace MAAP.AIPALS.Samples.AdaptiveAlgorithm
{
    /// <summary>
    /// 適性推薦演算法核心邏輯範例
    /// 負責依據學生作答表現動態計算推薦分數 (Ar)
    /// </summary>
    public class AdaptiveScoreCalculator
    {
        /// <summary>
        /// 更新學生的推薦分數
        /// </summary>
        /// <param name="currentScore">當前推薦分數 (0.0 ~ 1.0)</param>
        /// <param name="answeredCorrectly">是否答對</param>
        /// <param name="difficulty">題目難度 ("易", "中", "難")</param>
        /// <param name="accuracy">單元答題正確率 (0.0 ~ 1.0)</param>
        /// <returns>更新後的推薦分數 (0.0 ~ 1.0)</returns>
        public static double UpdateRecommendationScore(
            double currentScore, 
            bool answeredCorrectly, 
            string difficulty, 
            double accuracy)
        {
            // 邊界保護限制 (0.0 ~ 1.0)
            accuracy = Math.Max(0.0, Math.Min(1.0, accuracy));
            currentScore = Math.Max(0.0, Math.Min(1.0, currentScore));

            // 預設權重係數
            double gain = 0.05;
            double loss = 0.03;

            // 依據難度調整 Gain / Loss
            switch (difficulty)
            {
                case "易":
                    gain = 0.08;
                    loss = 0.02;
                    break;
                case "中":
                    gain = 0.06;
                    loss = 0.03;
                    break;
                case "難":
                    gain = 0.04;
                    loss = 0.04;
                    break;
                default:
                    break;
            }

            // 結合答題精準度的權重因子
            double correctFactor = 0.35 + 0.65 * accuracy;
            double wrongFactor = 0.60 + 0.40 * accuracy;

            // 計算動態增減量 Delta
            double delta = answeredCorrectly
                ? gain * correctFactor * (1.0 - currentScore)
                : -loss * wrongFactor * (0.5 + 0.5 * currentScore);

            // 計算並返回限制在 [0, 1] 區間的新分數
            return Math.Max(0.0, Math.Min(1.0, currentScore + delta));
        }
    }
}
