using System;
using System.Text.Json.Serialization;

namespace CongestionTax.Database
{
    /// <summary>
    /// Settings for firebase db. Used only in development, service account preferred in production.
    /// </summary>
    public class FirebaseSettings
    {
        [JsonPropertyName("type")]
        public string Type => "service_account";

        [JsonPropertyName("project_id")]
        public string ProjectId => "congestion-tax-calculator";

        [JsonPropertyName("private_key_id")]
        public string PrivateKeyId => "<Private key id>";

        [JsonPropertyName("private_key")]
        public string PrivateKey => "<Private key>";

        [JsonPropertyName("client_email")]
        public string ClientEmail => "<client email>";

        [JsonPropertyName("client_id")]
        public string ClientId => "<client id>";

        [JsonPropertyName("auth_uri")]
        public string AuthUri => "https://accounts.google.com/o/oauth2/auth";

        [JsonPropertyName("token_uri")]
        public string TokenUri => "https://oauth2.googleapis.com/token";

        [JsonPropertyName("auth_provider_x509_cert_url")]
        public string AuthProviderX509CertUrl => "https://www.googleapis.com/oauth2/v1/certs";

        [JsonPropertyName("client_x509_cert_url")]
        public string ClientX509CertUrl => "<cert>";

    }
}

