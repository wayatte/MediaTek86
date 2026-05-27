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

## Modèle Conceptuel de Données (MCD)

```
+----------------+       +-------------------+       +-----------+
|   responsable  |       |      absence       |       |   motif   |
+----------------+       +-------------------+       +-----------+
| idresponsable  |       | idpersonnel (FK)  |------>| idmotif   |
| login          |       | datedebut         |       | libelle   |
| mdp (SHA-256)  |       | datefin           |       +-----------+
+----------------+       | idmotif (FK)      |
                         +-------------------+
                                  ^
+----------------+               |
|   personnel    |---------------+
+----------------+
| idpersonnel    |
| nom            |
| prenom         |
| telephone      |
| idservice (FK) |
+----------------+
        |
        v
+----------------+
|    service     |
+----------------+
| idservice      |
| libelle        |
+----------------+
```

> Le MCD complet en image est disponible dans le dossier `/docs/`

---

## Interfaces de l'application

| Formulaire     | Description                                                        |
|----------------|--------------------------------------------------------------------|
| FrmConnexion   | Page de connexion avec vérification du mot de passe SHA-256        |
| FrmPersonnel   | Liste du personnel + boutons CRUD + accès aux absences             |
| FrmAbsence     | Liste des absences d'un agent + CRUD + vérification chevauchement  |

---

## Diagramme de paquetages (Architecture MVC)

```
MediaTek86/
│
├── bddmanager/          --> Singleton de connexion MySQL (BddManager.cs)
│
├── modele/              --> Classes métier (Personnel.cs, Absence.cs, Motif.cs...)
│
├── dal/                 --> Requêtes SQL paramétrées (AccesPersonnel.cs, AccesAbsence.cs...)
│
├── controlleur/         --> Logique métier, lien entre Vue et DAL
│                            (PersonnelController.cs, AbsenceController.cs)
│
└── vue/                 --> Formulaires Windows Forms
                             (FrmConnexion.cs, FrmPersonnel.cs, FrmAbsence.cs)
```

**Flux MVC :**
```
[Vue] --> appelle --> [Contrôleur] --> appelle --> [DAL] --> requête --> [MySQL]
[Vue] <-- affiche <-- [Contrôleur] <-- retourne <-- [DAL] <-- résultat <-- [MySQL]
```

---

## Étapes de construction – Historique des commits

```
git log --oneline (résumé)

1. init: création du projet Visual Studio et structure des packages (modele, dal, controlleur, vue, bddmanager)
2. feat(bdd): ajout du singleton BddManager pour la connexion MySQL
3. feat(auth): ajout du formulaire de connexion avec hachage SHA-256
4. feat(personnel-modele): ajout de la classe Personnel.cs
5. feat(personnel-dal): ajout de AccesPersonnel.cs avec requêtes SQL SELECT, INSERT, UPDATE, DELETE
6. feat(personnel-controlleur): ajout de PersonnelController.cs
7. feat(personnel-vue): ajout de FrmPersonnel avec liste et boutons CRUD
8. feat(absence-modele): ajout des classes Absence.cs et Motif.cs
9. feat(absence-dal): ajout de AccesAbsence.cs avec vérification anti-chevauchement SQL
10. feat(absence-controlleur): ajout de AbsenceController.cs avec contrôles de dates
11. feat(absence-vue): ajout de FrmAbsence avec CRUD complet
12. fix: correction affichage liste absences après modification
13. docs: ajout du README et du script SQL
```

---

## Procédure d'installation

### Prérequis

- Windows 10 ou 11
- [WampServer](https://www.wampserver.com/) installé et démarré (Apache + MySQL)
- [Visual Studio 2022](https://visualstudio.microsoft.com/fr/) avec la charge de travail **.NET Desktop**
- Package NuGet : `MySql.Data` (installable via NuGet dans Visual Studio)

### Étapes

**1. Cloner le dépôt**
```bash
git clone https://github.com/wayatte/mediatek86.git
cd mediatek86
```

**2. Importer la base de données**
- Ouvrir **phpMyAdmin** (`http://localhost/phpmyadmin`)
- Créer une base de données nommée `mediatek86`
- Importer le fichier `docs/mediatek86.sql`

**3. Configurer la connexion**

Ouvrir `bddmanager/BddManager.cs` et vérifier les paramètres :
```csharp
private static string server   = "localhost";
private static string database = "mediatek86";
private static string uid      = "root";
private static string password = ""; // vide par défaut sur WampServer
```

**4. Ouvrir et lancer le projet**
- Ouvrir `MediaTek86.sln` dans Visual Studio 2022
- Faire clic droit sur le projet > **Gérer les packages NuGet** > installer `MySql.Data`
- Appuyer sur **F5** pour lancer

**5. Se connecter**
- Login : `admin`
- Mot de passe : `adminpass` *(ou celui défini dans la table `responsable`)*

---

## Technologies utilisées

| Technologie     | Usage                        |
|-----------------|------------------------------|
| C# .NET Framework | Langage principal           |
| Windows Forms   | Interface graphique           |
| MySQL           | Base de données               |
| WampServer      | Serveur local MySQL           |
| MySql.Data      | Connecteur MySQL pour C#      |
| Visual Studio 2022 | IDE de développement       |
| Git / GitHub    | Versioning et dépôt distant   |

---

## Auteur

**AOUABED Wayatte** – BTS SIO SLAM – CNED  
Portfolio : [wayatte.github.io/portfolio](https://wayatte.github.io/portfolio)
