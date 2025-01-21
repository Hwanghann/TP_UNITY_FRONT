using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public ApiManager apiManager; // Référence au gestionnaire API
    public Text statsText; // Référence au bloc de texte pour afficher les stats

    private async void Start()
    {
        // Récupérer les stats dès le démarrage
        await FetchAndDisplayStats();
    }

    private async System.Threading.Tasks.Task FetchAndDisplayStats()
    {
        try
        {
            // Appelle l'API pour récupérer les stats
            string stats = await apiManager.GetStats();

            // Affiche les stats dans le bloc de texte
            statsText.text = stats;
        }
        catch (System.Exception ex)
        {
            // Affiche un message d'erreur en cas de problème
            statsText.text = $"Erreur lors de la récupération des stats : {ex.Message}";
        }
    }
}
