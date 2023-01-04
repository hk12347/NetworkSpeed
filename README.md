## NordCloud Tech assignment - Network speed

`.NET 6.0 Web API (C#)`

`Visual Studio 2022`

------

#### **How to run the solution** (Local Computer)

1. Use git to clone a Git repository to a specific folder on your local machine.

2. Start Visual Studio (2022)

   - **File** -> **Open** -> **Project/Solutions** -> `NetworkSpeedAPI.sln`
   - **Debug** -> **Start  Without Debugging** (Ctrl + F5) 

3. In the **Swagger UI** click the **GET**, **Try it out** and **Execute** buttons (`/GetNetworkSpeed`).

   **OR**

   Browser: Firefox, Chrome, Edge. 

   URL: http://localhost:5080/GetNetworkSpeed

   Port (5080) can be changed in `properties\launchSettings.json` (in the Solution Explorer).

   


The **response example** (response body)

```json
{
  "result": [
    "Best network station for point 12,34 is 56,78 with speed 90",
    "No link station within reach for point 123,45"
  ]
}
```

------

#### **Unit testing** (xUnit Test Project / .NET Core) 

When application is not running

- Visual Studio -> **Test** -> **Run All Tests**

---

#### Publish the Web API App to Azure App Service

Manual Steps 

1. In Visual Studio, in the Solution Explorer, right click on the **Network Speed API** project and click on **Publish**.

2. Select **Azure** and click **Next**.

3. Select **Azure App Service (Windows)** and click **Next**.

4. Select **Create a new Azure App Service**.

   The **Create App Service** dialog appears. The **App Name**, **Resource Group**, and **App Service Plan** entry fields are populated. You can keep these names or change them.

5. Click **Create**.

6. Once the app service is created, click **Next** .

7.  Select the checkbox **Skip this step** and click **Finish** (In Azure API Management). 

8.  At this point, you should be  on the **Publish** page in Visual Studio. 

9. Click the **Publish** Button.

   

After the deployment is complete. Navigate to the `https://<name>.azurewebsites.net/GetNetworkSpeed`



------

[^]: (C) HKuokkanen 2.1.2023. 