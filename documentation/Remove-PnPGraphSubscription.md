---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/remove-pnpgraphsubscription
schema: 2.0.0
title: Remove-PnPGraphSubscription
---

# Remove-PnPGraphSubscription

## SYNOPSIS
Removes an existing Microsoft Graph subscription. Required Azure Active Directory application permission depends on the resource the subscription exists on, see https://docs.microsoft.com/graph/api/subscription-delete#permissions.

## SYNTAX

```powershell
Remove-PnPGraphSubscription -Identity <GraphSubscriptionPipeBind>  [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Remove-PnPGraphSubscription -Identity bc204397-1128-4911-9d70-1d8bceee39da
```

Removes the Microsoft Graph subscription with the id 'bc204397-1128-4911-9d70-1d8bceee39da'

## PARAMETERS

### -Identity
The unique id or an instance of a Microsoft Graph Subscription

```yaml
Type: GraphSubscriptionPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)