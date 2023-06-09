# Creation, communication and containerization of microservices in local docker & local kubernetes & Azure Kubernetes Service (AKS) 

### Environment - .NET 6.0
### Language - C#

In this code repo I have shown to how to create and run microservices in differnt platforms. I have created two projects in the same solution for API and consumer(client) but in real world APIs may be kept in one solution and consumer may vary and can be kept in other differnt repos.

## 1. Local docker Run:: 
As container orchestration I have used docker compose. Pls check docker-compose.yml & docker-compose.override.yml where I have added the microservices(API, client & mongoDB) as service and done the configuration. individual docker file is there in project.  You just need to set the docker-compose project as start project and run the solution. All the images will be created and containers will be up and running. 
Once the containers will be running, check the port number from docker-compose.override.yml file and it you hit localhost on your system (Ex - http://localhost:7001/swagger/index.html) your swagger page will be up for API, similarly you can run the client project as well.  

You can create and run the containers using below command as well.

> docker-compose -f \\....\sardar-workorder\sardar-aks-e2e-workorder\Workorder\docker-compose.yml -f \\....\sardar-workorder\sardar-aks-e2e-workorder\Workorder\docker-compose.override.yml up -d

-d is used to run in background (in detached mode)

You can check if the status of the containers using below command.

> docker ps
 
## 2. Local kubernetes Run:: 
If you have docker desktop and want to run the kubernetes pods in docker desktop host then you need to enable kubernetes first. and the same can be done from docker desktop app as below. 
<img width="630" alt="image" src="https://github.com/souviksardar1/sardar-aks-e2e-workorder/assets/52888363/4e80fc9c-3058-466a-b1d5-bbf5b9f4e05e">

Once local k8s will be up and running, you can run your project in local kubernetes. We need manifest files to run the pods. I have written all the manifest files required for this project in 'kubernetes-Local' folder. You can check and run each yaml files one by one but to run the pods in one go you can apply the 'kubernetes-Local' folder directly using below command.
> kubectl apply -f C:\Souvik-P\sardar-workorder\sardar-aks-e2e-workorder\kubernetes-Local

Check the status of the pods using,

> kubectl get pods

Check the nodePort in deployment yaml and if your pods are up and running, you will see the microservices in localhost running via docker desktop kubernetes. (Ex - API will be up here, http://localhost:31000/swagger/index.html)

NOTE: In kubernetes NodePort is used to check application locally.






