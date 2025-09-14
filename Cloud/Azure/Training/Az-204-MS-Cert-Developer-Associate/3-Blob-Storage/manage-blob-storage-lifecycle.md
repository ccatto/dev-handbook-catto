# Manage the Azure Blob Storage Lifecycle

Learn how to manage data availability throughout the Azure Blob storage lifecycle.  

## Learning Objectives
After completing this module, you will be able to:  
- Describe how each of the access tiers is optimized  
- Create and implement a lifecycle policy  
- Rehydrate blob data stored in an archive tier  

## Module Outline
- Introduction  
- Explore the Azure Blob storage lifecycle  
- Discover Blob storage lifecycle policies  
- Implement Blob storage lifecycle policies  
- Rehydrate blob data from the archive tier  
- Module assessment  
- Summary  


> Intro
- Describe how each of the access tiers is optimized.
- Create and implement a lifecycle policy.
- Rehydrate blob data stored in an archive tier.

> Azure Blob storage supports different access tiers—Hot, Cool, Cold, and Archive—so you can store data in the most cost-effective way based on how often it’s accessed. Lifecycle management policies let you automate transitions between tiers or delete data when it’s no longer needed. By aligning storage tiers with data usage patterns, you can optimize both performance and cost throughout the data lifecycle.

> # Discover Blob Storage Lifecycle Policies

Azure Blob Storage lifecycle policies are JSON-based collections of rules that automate data management, such as tiering and deletion.  
Each rule has filters (to target specific blobs) and actions (to move or delete blobs based on conditions).  
This helps optimize storage costs by transitioning data between tiers or expiring it when no longer needed.

### Example Lifecycle Rule
```json
{
  "rules": [
    {
      "enabled": true,
      "name": "sample-rule",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "baseBlob": {
            "tierToCool": { "daysAfterModificationGreaterThan": 30 },
            "tierToArchive": { "daysAfterModificationGreaterThan": 90 },
            "delete": { "daysAfterModificationGreaterThan": 2555 }
          }
        },
        "filters": {
          "blobTypes": ["blockBlob"],
          "prefixMatch": ["sample-container/blob1"]
        }
      }
    }
  ]
}
```

#### Implement Blob Storage Lifecycle Policies

> You can create, edit, or remove lifecycle management policies using the **Azure portal**, **Azure CLI**, **PowerShell**, or **REST APIs**.  
Policies are defined in JSON and applied at the storage account level to automate actions like tiering and deletion.  
In the portal, you can use **Code View** to define policies directly, while in the CLI you provide a JSON file with rules when running `az storage account management-policy create`.  
Note: Policies must always be read or written in full — partial updates aren't supported.  

> Azure archived blobs are offline and must be rehydrated to hot or cool tiers before they can be accessed or modified. Rehydration can be done either by copying the blob to an online tier or by changing its access tier with the Set Blob Tier operation. The process can take hours, but priority can be set to Standard (up to 15 hours) or High (under 1 hour for blobs <10GB). Microsoft recommends rehydrating larger blobs for efficiency and being cautious with lifecycle policies that might re-archive data.

## Quiz: Azure Blob Storage Lifecycle

1. **Which access tier is considered to be offline and can't be read or modified?**  
   - Cool  
   - **Archive ✅**  
   - Hot  

2. **Which of the following storage account types supports lifecycle policies?**  
   - General Purpose v1  
   - **General Purpose v2 ✅**  
   - FileStorage  

* types of Azure Storage accounts
- GPv1 = legacy, limited.
- GPv2 = modern, versatile, recommended.
- FileStorage = premium, for Azure Files only.

> Summary

- Describe how each of the access tiers is optimized.
- Create and implement a lifecycle policy.
- Rehydrate blob data stored in an archive tier.

