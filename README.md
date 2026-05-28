# MediaTek86 – Gestion du Personnel et des Absences

> Atelier 2 – BTS SIO option SLAM | CNED  
> Développeur : AOUABED Wayatte

---

## Présentation du contexte

Dans le cadre de ma première année de **BTS SIO option SLAM** au CNED, j'ai réalisé l'atelier 2 : **MediaTek86**.

La médiathèque de la Vienne (86) a besoin d'une application pour gérer son personnel et leurs absences. Le responsable de la médiathèque doit pouvoir :
- Se connecter à l'application de façon sécurisée
- Consulter et gérer la liste des agents (personnel)
- Consulter et gérer les absences de chaque agent, avec un système qui empêche les chevauchements de dates

---

## But de l'application

L'application **MediaTek86** est une application de bureau (Windows Forms, C#) connectée à une base de données MySQL. Elle permet :

- L'**authentification** du responsable (mot de passe haché en SHA-256)
- La **gestion complète du personnel** (Afficher / Ajouter / Modifier / Supprimer)
- La **gestion complète des absences** par agent (Afficher / Ajouter / Modifier / Supprimer)
- La **vérification automatique des chevauchements de dates** : si on essaie d'ajouter une absence dont les dates empiètent sur une absence existante, l'application bloque l'opération et affiche un message d'erreur clair

---

