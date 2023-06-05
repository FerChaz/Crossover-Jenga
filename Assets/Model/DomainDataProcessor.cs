using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DomainDataProcessor
{
    private APIGateway apiGateway;

    public DomainDataProcessor()
    {
        apiGateway = new APIGateway();
    }

    public void FetchDataFromApi(Action<List<DomainObject>> callback)
    {
        CourutineStarter.Instance.StartCoroutine(apiGateway.GetDataFromApi(response =>
        {
            List<DomainObject> dataObjects = ProcessApiResponse(response);
            callback?.Invoke(dataObjects);
        }));
    }

    public List<DomainObject> ProcessApiResponse(string response)
    {
        Debug.Log(response);
        List<DomainObject> dataObjects = new List<DomainObject>();

        try
        {
            DomainObject[] dataArray = JSONHelper.FromJson<DomainObject>(JSONHelper.FixJSON(response));
            dataObjects.AddRange(dataArray);
            
            dataObjects = dataObjects.OrderBy(obj => obj.grade)
                .ThenBy(obj => obj.domain)
                .ThenBy(obj => obj.cluster)
                .ThenBy(obj => obj.standardid)
                .ToList();
        }
        catch (Exception e)
        {
            Debug.LogError("Error processing API response: " + e.Message);
        }

        return dataObjects;
    }
}
