   M S B A M L   `   `   `  ����E  ASapphirApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SapphirApp.ViewsSapphirApp.Views  5      c _Syncfusion.SfKanban.WPF, Version=20.4600.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89fHclr-namespace:Syncfusion.UI.Xaml.Kanban;assembly=Syncfusion.SfKanban.WPFSyncfusion.UI.Xaml.Kanban 5      =#clr-namespace:SapphirApp.ViewModelsSapphirApp.ViewModels  5      "    SapphirApp.Views.KanbanBoard   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SapphirApp.Views     5      _
syncfusionHclr-namespace:Syncfusion.UI.Xaml.Kanban;assembly=Syncfusion.SfKanban.WPF     5      :
viewmodels#clr-namespace:SapphirApp.ViewModels     5        � 	Resources  5         ShowGrid��%   &	        �� 5   
   6'   5      .��5      � 
������ .+�5   
   (  "Syncfusion.UI.Xaml.Kanban.SfKanban  
������    MinColumnWidth$	 200Q�5         MaxColumnWidth$	 400Q�5      $��0q�5         AutoGenerateColumns$ False��5         ColumnMappingPath$ Category��5      {�5      �� *IsKanbanEnabled+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   ItemsSource 5      �� *Tasks+$ TwoWay=�$ PropertyChanged=�   ColumnHeaderTemplate 5      �� 5      	 �� DataType$	 syncfusion:ColumnTag��6   .R�5      �� ._�5      �� 
 �� Orientation$
 
Horizontal=�5      $��5,5,0,0q�5      .+�5       ]� .+�5!   "   �� $��Right=�6)   $��+��5"   )   $��20��5#   )   $��20��65   
�������  AddTasks#��[ 5%   )   ��5&   )   ��  �� RelativeSource ��  �� AncestorType"   �� Path$# DataContext.ShowGridToAddTask���5'   )   �� *Header+$ TwoWay=�$ PropertyChanged=��� 5(   "   $��12(�5)   ,   $��0,0,15,0q�6:   ��5(   ,   �� *Header+$ TwoWay=�$ PropertyChanged=�5)   :   5*      5+      5,      5-         CardTemplate 5/      �� 50      .R�51      �� $��1q�6    �� CornerRadius$ 4��52      
�������$��0,5,0,5q�54      ._�55      �� $��	10,5,5,10q�6%   .+�56      ��  �� TextWrapping$
 Wrap=�57   &   ${�False��58   &   $��0q�59   &   $��16(�5:   &   $
��Bold"�5;   &   ��56   &   �� *ShortNumber+$ TwoWay=�$ PropertyChanged=�5;   &   �� 5<      $
 Wrap=�5=   &   ${�False��5>   &   $��0q�5?   &   $��16(�5@   &   $
��Bold"�5A   &    �� MaxLines$ 2��5B   &   ��5<   &   �� *Name+$ TwoWay=�$ PropertyChanged=�5B   &   �� 5C      $��14(�6&   $��0q�5D   &   ${�False��5E   &   $
��Left=�5F   &   $ 3��5H   &   $
 Wrap=�5I   &   ��5G   &   �� *Description+$ TwoWay=�$ PropertyChanged=�5I   &   �� 5J      $��Pokaż��6%   ��65   ��  �� "  $ DataContext.TaskShow���5K   %   �� *ShortNumber+$ PropertyChanged=�$ TwoWay=�5L      5M      5N         Columns. 5Q      ,  &Syncfusion.UI.Xaml.Kanban.KanbanColumn     	AllowDrag$ False��6&    J� 	AllowDrop$ False��68      
IsExpanded$
 True��6J      
Categories$ 
Unassigned��6\      Title$ 
Unassigned��6t   
�������6�     5R      $ False��6&   $ False��68   $
 True��6J   $ Backlog��6\   $ Backlog��6q   
�������6�     5S      $ False��6&   $ False��68   $ False��6J   $ To Do��6]   $ To Do��6p   
�������6~     5T      $ False��6&   $ False��68   $ False��6J   $ In Progress��6]   $ In Progress��6v   
�������6�     5U      $ False��6&   $ False��68   $ False��6J   $ In Test��6]   $ In Test��6r   
�������6�     5V      $ False��6&   $ False��68   $ False��6J   $ Review��6]   $ Review��6q   
�������6�     5W      $ False��6&   $ False��68   $ False��6J   $ 	Completed��6]   $ 	Completed��6t   
�������6�   5X      � 5Z   
   
������ $	��500��5[      $	��400��6   y�5\      �� *IsGridVisible+ �� 	Converter# [  $ TwoWay=�$ PropertyChanged=� � RowDefinitions 5]   
   �� 5^      �� 5_      �� 5`      �� 5a       � ColumnDefinitions 5c      �� 5d      �� 5e      �� 5f      �� 5g      �� 5h      �� 5i      .+�5k      �� $��2q�6   
���   �
�������$��1��5m      $��4��5n      $��4��5o      ._�5p      �� 
������ $��
50,0,50,50q�5q      .+�5r      �� $��Nowe zgłoszenie��6    $��	0,10,0,15q�5s       $��16(�5t       $
��Bold"�5u       �� 5v      $��Tytuł:��6    �� 5w      ��6   �� *Name+$ TwoWay=�$ PropertyChanged=��� 5x      $��Opis:��6    �� 5y      $
 Wrap=�6   $ 10��62   " �� VerticalScrollBarVisibility$
 Auto=�5z      ��5{      �� *Description+$ TwoWay=�$ PropertyChanged=��� 5}      $��Przypisz do:��6    �� 5~      ��6   �� *AssignedUser+$ TwoWay=�$ PropertyChanged=��� 5      $��Tagi:��6    �� 5�      ��6   �� *Tag+$ TwoWay=�$ PropertyChanged=�5�      5�      �� 5�      
������ $��2��5�      $��5��6)   $��2��5�      .+�5�      �� $��Center=�6   $��Dodaj zadanie��5�      $	��100��5�      $��50��6%     NewProjectButton#��[ 5�      ��5�      �� *	AddTask+�� 5�      $��Center=�6   $��Anuluj��5�      $	��100��5�      $��50��6%   #��[ 5�      ��5�      �� *
CancelTask+5�      5�      � 5�   
   
������ y�5�      �� *IsTaskVisible+# [   5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $
��Auto=�6   $��1��5�      $��4��6+   $��4��5�      $��10,50q�6)   .��5�      �� 
�������$��5q�6,   ._�5�      �� $��5q�6!   .+�5�      �� $��X��6!   #��[ 5�   !   $��Right=�5�   !   ��5�   !   �� *	CloseTask+�� 5�      $
��Wrap=�6$   $��5q�5�      $��14(�5�      $��DemiBold"�5�      ��5�      �� *newTask.Name+$ PropertyChanged=�$ TwoWay=��� 5�      $��0,10,0,0q�6$   $��Opis:��66   �� 5�      $
 Wrap=�6"    �� 
IsReadOnly$
 True��66   $	��100��5�      ��5�      �� *newTask.Description+$ PropertyChanged=�$ TwoWay=��� 5�      $��Board:��6$   �� 5�      ��6#   �� *	Columns+$ PropertyChanged=�$ TwoWay=� �� SelectedValue 6t   �� *SelectedColumn+$ PropertyChanged=�$ TwoWay=��� 5�      $��Przypisz do:��6$   �� 5�      ��6"   �� *newTask.AssignedUser+$ PropertyChanged=�$ TwoWay=��� 5�      $��
Komentarz:��6$   �� 5�      $
 Wrap=�6"   $ 10��66   ��5�   "   �� *	Comment+�� 5�      $��Dodaj komentarz��6!   $��0,10,0,0q�5�   !   $��Right=�63   #��[ 5�   !   ��5�   !   �� *AddComments+�� 5�      $��0 0 1 0q�5�      
�������$
��Auto=�5�      
�������
���   �$��0,15,0,0q�5�      ��5�   '   �� *ListMessages+$ TwoWay=�$ PropertyChanged=���5�      �� 5�   "   .R�5�   &   � .+�5�   *   �� .+�5�   .   �� $
 
Horizontal=�69   .+�5�   2   �� $��5,0,5,0q�6�   ��6<   �� *
UserName+$ PropertyChanged=�$ TwoWay=�6�   �� 5�   2   ��6<   �� *Time+$ PropertyChanged=�$ TwoWay=�5�   /   �� 5�   .   $
 Vertical=�69   .+�5�   2   �� $��5,0,5,15q�6�   ��6<   �� *	Message+$ PropertyChanged=�$ TwoWay=�6�   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      $��0,10,0,0q�6!   #��[ 63   $��Aktualizauj��5�   !   ��5�   !   �� *
UpdateTask+��5�   !   �� *newTask.AssignedUser+5�      5�      5�      5�      5�      5�      