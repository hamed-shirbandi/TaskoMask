# ApiGateways
In this section, we apply API Gateway pattern to our microservices. Here are some tips related to API Gateways:
> * Following Backend For Frontend (BFF) pattern, we have prepared the architecture to have different Gateways for each client. For now, we just have UserPanel ApiGateway to be used for its web project, maybe in the future we decide to have a native mobile client for it, so we can add a new gateway in UserPanel folder and separate web and mobile gateways.
> * Aggregator is something like a microservice on the read side. Its duty is to get data from different services and composite them into the desired data requested from clients.


# Ocelot
We use Ocelot for implementing our API Gateways. If you need to know more about it, we recommend reading [its documents](https://ocelot.readthedocs.io/). Here are some tips related to Ocelot configurations:
> * We have Authentication section in each ocelot configs. It handles authentication for us and prevent to proccess unauthorized request through the microservices. But, as this source is a learning resource we do the authentication through each microservice too.