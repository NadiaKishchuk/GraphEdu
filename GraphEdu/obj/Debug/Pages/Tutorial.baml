   M S B A M L   `   `   `  ����C  ?GraphEdu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:GraphEdu.TutorialUserControllerGraphEdu.TutorialUserController  5      /clr-namespace:GraphEdu.PagesGraphEdu.Pages  5          GraphEdu.Pages.Tutorial   5      HTutorialUserController-clr-namespace:GraphEdu.TutorialUserController  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.58.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aaR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GraphEdu.Pages     5        N� Title$  Tutorial��5
       � 	Resources 5       �� 
TargetType   my:textBlockMenu �� Property �� Value  my:imageMenu��%  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 22(�6*   �� 5       � ��$ 
Nirmala UI)�6,   �� 5       � ��$ 15q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 25��6&   �� 5       � ��$ 25��6'   5      5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��810 �6   �� 5      $	��300 �6   .+�5   
   �� $
��Left=�6   ���#858DC9$	��Top=�6G   .+�5      �� $��0q�6   $	��182��6$   $	��Top=�64   ���#858DC9$	��280��6a   $	��280��6m   .+�5       ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� #��[ 6   $%��/images/TutorialImages/quiz.png��6B   �� 5#      ���#AAAAAA#��[  66   $��Take a quiz��6`   5$      �� 5%      -   5        $ 
Horizontal=�5%      .+�5&      �� #��[ 6   $&�� /images/TutorialImages/snake.png��6B   �� 5(      -   5         ��Name$ SnakeTextBox��5(   6   $��DemiBold"�6    #��[  6L   $��Play snake game��6v   5)      �� 5*      -   5        $ 
Horizontal=�5*      .+�5+      �� #��[ 6   $*��$/images/TutorialImages/open-book.png��6B   �� 5-      -   5        $ InformationTextBox��5-   !   #��[  6=   $��Read information��6g   5/      51      � 53      ���#858DC9$��0q�6(    54      �� 55      $��50 �6'   �� 56       � RowDefinitions 58      �� 59      �� 5:      �� 5;      .+�5=      �� -   5        $ ColorTextBox��5=      $��0��63   $��1��6@   $
��Left=�6P   #��[  6l   $��
• Colors��6�   6�   �� 5>      -   5        $ FigureMovingTextBox��5>      $��1��6:   $��1��6G   $
��Left=�6W   #��[  6s   $��• Figure moving��6�   6�   �� 5?      -   5        $ FractalTextBox��5?      $��2��65   $��1��6B   $
��Left=�6R   #��[  6n   $��• Fractals��6�   6�   5A      5I      /   )GraphEdu.TutorialUserController.GameSnake  5J   
   -   5        	  Name$	 SnakeControl��5J   ;   $��1��6+   $	��810��6Q   $	��650��6]   |�. $	��Top=�6|   ?   9GraphEdu.TutorialUserController.InformationUserController  5K   
   -	   5        
  Name$
 InformationController��5K   ;   $��1��6Z   $y�Hidden=�6j   $	��Top=�6~   �� 5L   
   $	��100��6   $	��100��6   $��2��6)   $��Bottom=�69   $��/images/catSmile.png��6T   $��0 0 0 15q�6r   5O      5P      