   M S B A M L   `   `   `  ����L  HEvolutionEndeavor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EvolutionEndeavorSystemEvolutionEndeavorSystem  5      ,    &EvolutionEndeavorSystem.XAML.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:EvolutionEndeavorSystem     5      $	��300��5      $	��500��6,     � 	Resources  5	       �� Source�� 5
   
   $ SharedResources.xaml?�6   %    .��5      � $
��Auto��6   $	��Top=�6   .+�5   
   �� $��0��6   $��0��6    �� 5   
   $��0��6   $��2��6    $��	UserName:��6-   �� 5   
   $��0��6   $��4��6    $��	Password:��6-   �� 5   
   $��0��6   $��6��6    �� 5   
   $��0��6   $��8��6    $��Load Saved Game: ��6-   �� 5   
   $��2��6   $��2��6"   ��6/   ��  �� Path$ UserName� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��2��6   $��4��6"   ��6/   �� $ Password�$ PropertyChanged=��� 5   
   $��2��6   $��10��6#   ��61   �� $ 
SavedGames� �� SelectedItem 6Y   �� $
 Game�$ PropertyChanged=��� 5   
   $��2��6   $��12��6)   ��67   �� $ Commands���6Y   �� *+)StaticResource HorizontalCommandsTemplate+6�    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��4 �6   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��4 �6   �� 5#      $
��Auto �6   �� 5$      $��4 �6   �� 5%      $
��Auto �6   �� 5&      $��4 �6   �� 5'      $
��Auto �6   �� 5(      $��4 �6   �� 5)      $
��Auto �6   5-      5.      