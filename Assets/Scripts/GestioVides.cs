using TMPro;
using UnityEngine;

public class GestioScore : MonoBehaviour
{
   [SerializeField] int score;
   [SerializeField] TextMeshProUGUI textScore;

   public void augmentarScore()
   {
      score++;
      print(score);
      textScore.text = $"Puntuacio: {score}";        
   }
   public void disminuirScore()
   {
      score--; 
      print(score);
      textScore.text = $"Puntuacio: {score}";        
   }
}
