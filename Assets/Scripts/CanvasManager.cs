using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvasConnexion; // Référence au Canvas de connexion
    public GameObject canvasStats;     // Référence au Canvas de statistiques
    public GameObject canvasComm; 

    void Start()
    {
        // Vérification des références
        if (canvasConnexion == null || canvasStats == null)
        {
            Debug.LogError("Les Canvas ne sont pas correctement assignés dans l'inspecteur !");
            return;
        }

        // Assurez-vous que seul le Canvas de connexion est visible au démarrage
        canvasConnexion.SetActive(true);
        canvasStats.SetActive(false);
        canvasComm.SetActive(false);
    }

    // Fonction appelée lors du clic sur le bouton de connexion
    public void ShowStatsCanvas()
    {
        if (canvasConnexion != null && canvasStats != null)
        {
            canvasConnexion.SetActive(false); // Désactiver le Canvas de connexion
            canvasStats.SetActive(true);      // Activer le Canvas des stats
            canvasComm.SetActive(false);
        }
    }

    // Fonction appelée pour revenir au Canvas de connexion
    public void ShowConnexionCanvas()
    {
        if (canvasConnexion != null && canvasStats != null)
        {
            canvasConnexion.SetActive(true);  // Activer le Canvas de connexion
            canvasStats.SetActive(false);     // Désactiver le Canvas des stats
            canvasComm.SetActive(false);
        }
    }

    public void ShowCommentaireCanvas()
    {
        if (canvasConnexion != null && canvasStats != null)
        {
            canvasConnexion.SetActive(false);  // Activer le Canvas de connexion
            canvasStats.SetActive(false);     // Désactiver le Canvas des stats
            canvasComm.SetActive(true);
        }
    }
}
