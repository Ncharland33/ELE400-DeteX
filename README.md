# ELE400-DeteX
Dependencies
--------------------
- RestSharp
- Newtonsoft.Json

Documentation
--------------------
Connect Device
https://docs.microsoft.com/fr-ca/azure/iot-hub/quickstart-send-telemetry-dotnet#code-try-1

Web App
https://docs.microsoft.com/fr-ca/azure/app-service/app-service-web-get-started-dotnet


Prérequis

-Kit SDK .NET Core 2.1.0 ou version ultérieure
https://dotnet.microsoft.com/download/archives
-Visual Studio 2019 avec Développement ASP.NET et web (Outils > Obtenir des outils et des fonctionnalités)

Hub Information

-Nom du IoT Hub --> ELE400-DeteX-hub

-Nom test device --> MyDotnetDeviceTest

-Chaîne de connexion --> HostName=ELE400-DeteX-hub.azure-devices.net;DeviceId=MyDotnetDeviceTest;SharedAccessKey=1cvGV0i7xYGvf4rO/xoVYoxnbtkIrwcfk+I+E2tvuio=

-Point de terminaison compatible Event Hubs --> "sb://ihsuprodyqres016dednamespace.servicebus.windows.net/"

-Chemin d'acces compatible Event Hubs --> "iothub-ehub-ele400-det-1786549-3d92aa99c8"

-clé principale iothubowner --> "vLDlKjrDA5250Oir9v+Mu4VkOV72vJb4+YF7fyY0J7c="



Commande PowerShell
-dotnet restore
-dotnet run


Web App
http://ELE400-DeteX-WebApp20190618044131.azurewebsites.net


Git Hub
Download Git (ouvrir un git, right click + ouvrir git bash)

-Ouvrir le projet
Va dans fichier ou tu veux mettre projet
-git clone https://github.com/Ncharland33/ELE400-DeteX.git (pour coller shift+insert)

-ouvre dans le fichier qui a ete download
-prendre info
git pull
-ajouter info
git add *
git commit -m "message"
git push

Pour regarder changement
git status
