using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ApiManager : MonoBehaviour
{
    private readonly string baseUrl = "http://localhost:5083/api"; // URL de ton API
    private HttpClient httpClient;

    private void Awake()
    {
        httpClient = new HttpClient();
    }

    /// <summary>
    /// Récupère les stats du joueur.
    /// </summary>
    /// <returns>Les stats sous forme de chaîne.</returns>
    public async Task<string> GetStats()
    {
        try
        {
            string url = $"{baseUrl}/stats"; // Endpoint pour récupérer les stats
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string stats = await response.Content.ReadAsStringAsync();
                return stats;
            }
            else
            {
                Debug.LogError($"Erreur lors de la récupération des stats : {response.StatusCode}");
                return "Erreur : Impossible de récupérer les stats.";
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception lors de la récupération des stats : {ex.Message}");
            return $"Erreur : {ex.Message}";
        }
    }

    /// <summary>
    /// Tente de connecter un utilisateur avec un nom d'utilisateur et un mot de passe.
    /// </summary>
    /// <param name="username">Nom d'utilisateur</param>
    /// <param name="password">Mot de passe</param>
    /// <returns>True si la connexion réussit, sinon false.</returns>
    public async Task<bool> Login(string username, string password)
    {
        try
        {
            string url = $"{baseUrl}/auth/login"; // Endpoint pour la connexion
            var loginData = new { Username = username, Password = password }; // Objet de requête
            string json = JsonUtility.ToJson(loginData);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Connexion réussie !");
                return true;
            }
            else
            {
                Debug.LogError($"Erreur de connexion : {response.StatusCode}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception lors de la connexion : {ex.Message}");
            return false;
        }
    }
}
