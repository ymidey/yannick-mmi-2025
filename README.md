# Projet d'exercice MMI 2025

# Setup

## Dupliquer le dépôt d'exercice
> [!NOTE]
> Étapes extraites du tutorial Git pour [Dupliquer un référentiel](https://docs.github.com/fr/pull-requests/collaborating-with-pull-requests/working-with-forks/fork-a-repo#forking-a-repository)

1. Dans le coin supérieur droit de la page, cliquez sur **Fork**.
2. Sous « Propriétaire », sélectionnez le menu déroulant et cliquez sur un propriétaire pour le dépôt dupliqué.
3. Dans le champ « Nom du dépôt », changer le nom du référentiel en suffixant par votre prénom.
4. Sélectionnez "Copier la branche **PAR DÉFAUT** uniquement".
5. Cliquez sur "**Créer une duplication**".

## Cloner le dépôt dupliqué
> [!NOTE]
> Étapes extraites du tutorial Git pour [Cloner un dépôt dupliqué](https://docs.github.com/fr/pull-requests/collaborating-with-pull-requests/working-with-forks/fork-a-repo#cloning-your-forked-repository)

1. Sur GitHub.com, accédez à votre duplication du dépôt
2. Au-dessus de la liste des fichiers, cliquez sur Code.
3. Copiez l’URL du dépôt.
4. Ouvrez [Git Bash](https://git-scm.com/downloads)
5. Naviguez jusqu'à l’emplacement où vous voulez mettre le répertoire cloné en utilisant la [commande _cd_](https://graphite.dev/guides/change-directories-git-bash-windows)
6. Tapez git clone, puis collez l’URL que vous avez copiée précédemment.
7. Appuyez sur Entrée. Votre clone local va être créé.

## Ouvrir votre projet Unity

1. Ouvrez Unity Hub et sélectionnez l'onglet Projects dans la barre de menu à gauche
2. Appuyez sur le bouton Add en haut à droite
3. Sélectionnez le répertoire du projet
4. Cliquez sur le bouton Open et attendez l'ouverture du projet

# Premiers pas dans Unity

> [!NOTE]
> Pour plus de détails vous pouvez suivre le tutorial [ici](https://learn.unity.com/tutorial/explore-the-unity-editor-1)

## L'interface de l'éditeur
![Image d'illustration dez zones de l'éditeur](https://unity-connect-prd.storage.googleapis.com/20220606/learn/images/7fabb375-5282-4852-9ecf-d8acc254052b_EditorExplore.png)

### Scene view et Game view 
Zones de visualisation des objets 3D (**Scene**) et la vue joueur (**Game**)
> [!TIP]
> Avec le layout par défaut la Game View apparaît au même endroit. Utiliser les onglets pour naviguer.

### Hierarchy window 
Collection d’objets dans la scene.

### Project window 
Équivalent d’un explorateur de fichiers pour le projet.

### Toolbar 
Outils de navigation et de manipulation dans la scène

### Inspector window 
Panneau de configuration d’un objet sélectionné.

## Manipuler les objets 3D
![Image d'illustration des outils de transformation](https://unity-connect-prd.storage.googleapis.com/20220601/learn/images/057c859e-04d5-429a-b980-b852a80b2015_gizmos.png)

- W: Outil de déplacement, pour sélectionner et bouger un objet
- E: Outil de rotation, pour sélectionner et tourner un objet
- R: Outil de dimensionnement, pour sélection et changer la taille d'un objet

> [!TIP]
> Utilisez les raccourcis par défaut W (Move), E (Rotate), R (Scale) pour sélectionner l'outil rapidement.

Pour chacun des outils de transformation, un Gizmo apparaît qui vous permet de manipuler le GameObject le long de chaque axe spécifique. 
Lorsque vous manipulez ces contrôles, les valeurs du composant Transform changent en conséquence.

## Créer une nouvelle scène
### Scène vide
1. Ouvrez le dossier **Assets/Scenes** dans la fenêtre Project
2. Cliquez droit pour ouvrir le menu contextuel
3. Sélectionnez **Create/Scene** 
4. Nommez la scène

### Template
1. Ouvrez le menu **File / New Scene…**
2. Sélectionnez le template souhaité
3. Sauvegardez la scène ouverte

### Ajouter la nouvelle scène au build
1. Ouvrez le sous-menu **Build Settings** depuis le menu **File**
2. Glissez/déposez la nouvelle scène
> [!TIP]
> Utilisez le raccourcis Ctrl+Shift+B pour ouvrir rapidement les Build Settings


