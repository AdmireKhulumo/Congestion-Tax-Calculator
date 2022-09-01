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
        public string PrivateKeyId => "8639524b6222315074151d15dfb6225b5cd1148b";

        [JsonPropertyName("private_key")]
        public string PrivateKey => "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC94fDAtV2qcuim\na9CzQ/F8MM/6LwXdpzu/VgRBxp+iRg+CgxMPkkw2xJu+Qq5MLTWL9htZIvO4Uirs\nyyVAq9jRc5BOd9+O7DoJsHxJXaiMXu8SbxCYS7+NxlCfcCFxQYrlCkzGeePFNWW4\nf6zxnkf1OLQN6atjCoMOe41RtB1TeBa3NiIJk2YCAQQn/lZuKbj6WJMY700vNdNK\n7U1QAtbX3swAKioFwmt5d8WAmz9bIk/XyJK3vKYtqC/3TRCj/wvMnQUSMVy22gZ9\ntIHKC8yufslqHX+JZJMgTAwTA6/FKraVlalhRDGH62WvA9fxzjOgKsgriAP07Ebe\n9NhlFg0lAgMBAAECggEADzqXQgVpw+QKZ7U0Rvm3MkQsnKlNJE1SJpLXWDp+DsLl\nYeIcUxPjMUNMexJtreYJqjYsqatQIQ4qANV8ITcxy6lOlL8wJWN/IMwlnlwOIA/0\ncaXfDq/d5u4rBNaL6sGcdP6B+4BxdZ1w5pQK1/1fUmS1VXunshOjljOaOR15JU/+\ny+45eaa3tx9WDKj0w7Ryc/L594aTOK2pN3D3solxxIkm0ewV0AfcITshgLCh28Hx\nF2QJ71vB7fxkMdq83dXJFrthy9n9y56fvMrg8XaucrbCQ2HJi0ILvn/ZrXzbFL/x\nTGpD1LD5vBwqlvZkj9I07Pa6lhfF9qnFCTzAAQLtowKBgQDhYqU7Nja4qlrpWT1J\nU+o2f6BO8mCaTtkZfVC3WCaojNLfUDATk73KgOEBBEw9ohVQlqEM0b7MLziQ27UT\n2Ilf5EYf/hRA2PCTIYZXbVQgRc7uH4hSgkVhrxYkGiEXLWkMxCDgkc58IBnuG/zU\nuKVzf0cdJknc3815Id+FSgSBCwKBgQDXrMDCNKw36CteXo3wdNIFny/S+ArZ6LRd\n7MYRPVSWnpyNVACxJF/YSXuchA/0xdRJrvX9oK7+Ixx7XvShGLS9W/c+3Md+vXZY\nEsKt0NLKQPdfWOZBrzzrTBGSagAK9mehX/aJuUScGWqmXXo47Q+uDxBid5/eJnr1\noJ4h6uDojwKBgQC70vAtew15MQZYBjVLoXHCfvNCNzyH+4NyeXtFf2Gf/tNQpEuc\nVPfKBUL9DO7YQfWPVifaPgTJteRm26F4a3B4CAzkZmHMdL1vb3W77/E2f9ZlnMOH\nNubI9Bb4eQnwfbhYmi1n2DqCOGJDivFU+Jdwu7WwthLBzYQ3GSJjun4sZwKBgBZg\nxl9gN75VSKqyBOg+Nsx+h+fL9NRHYO+d8a84Pd6i9ntzi97Vd1xpw3mp+j3biPtc\nPAnk8kNMQVhLsfZFKfu73xuWrNxprC3XRHvkfvqdYw1xm/KUzC1d5zTZ6sc4aehE\nnMANiSDpQjeg212su0PELF8LKntSYs+5qq66QDvhAoGAezDSzmBv39EAuH3ET+MT\niHnNmL4KyHAvqZhrIbv5BIFyR1u802JRqPmSjB1IDOolFFJ8XMjKyDTbdT5wCotC\n0oxBjcOpZFgJCLYjQ0o4F4fa6oeDFA//VlRD5FqUOiMNJhIZCYxIGmXkejzrUj4V\nqTpFhXyCJKJ4/ECXFdcJBnw=\n-----END PRIVATE KEY-----\n";

        [JsonPropertyName("client_email")]
        public string ClientEmail => "firebase-adminsdk-saog4@congestion-tax-calculator.iam.gserviceaccount.com";

        [JsonPropertyName("client_id")]
        public string ClientId => "112866230649810337935";

        [JsonPropertyName("auth_uri")]
        public string AuthUri => "https://accounts.google.com/o/oauth2/auth";

        [JsonPropertyName("token_uri")]
        public string TokenUri => "https://oauth2.googleapis.com/token";

        [JsonPropertyName("auth_provider_x509_cert_url")]
        public string AuthProviderX509CertUrl => "https://www.googleapis.com/oauth2/v1/certs";

        [JsonPropertyName("client_x509_cert_url")]
        public string ClientX509CertUrl => "https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-saog4%40congestion-tax-calculator.iam.gserviceaccount.com";

    }
}

