   M S B A M L   `   `   `  ����D  @CRM Tele2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRM_Tele2	CRM_Tele2  5   	       CRM_Tele2.OutGoingCall   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CRM_Tele2     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  OutGoingCall��5	   	   $	��384��6   $	��380��6+   $	��800��6;    � WindowStartupLocation$ CenterScreen=�6G   .��5
      � .+�5   
   �� $��20q�6   ���#eeeeee �� CornerRadius$ 20��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightBlue��63      ShadowDepth$ 0Q�6E   ._�5      � $��20q�6   ���#75a8fa.+�5      �� $
��Auto��6   .+�5      �� $��История��6!   $��20(�60   $��Heavy"�6>   $��5q�6Q   6^   � 5      
�������$	��100��6.   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ CallHistory��5   #   5      � 5       � ColumnDefinitions 5      �� 5      $��1* �6/   �� 5      $	��10* �6/   	 � RowDefinitions	 5      �� 5       �� 5!      �� 5"      .+�5$      �� $��0��6%   $��0��65   $��Телефон:��6C   
�������$��5,0,0,0q�6f   6y   �� 5%      -   5        
 ��Name$
 PhoneNumber��5%   #   $��1��68   $��0��6H   $��Stretch=�6U    �� 
IsEditable . 6s   �� 5&      $��0��6%   $��1��65   $��Имя:��6B   
�������$��5,0,0,0q�6a   �� 5'      $��0��6%   $��2��65   $��Адрес:��6B   
�������$��5,0,0,0q�6c   �� 5)      -   5         ��Name$
 Name��5)   $   $��1��62   $��1��6B   
�������$��5,0,0,0q�6c   �� 5*      -   5        $ Address��5*   $   $��1��65   $��2��6E   
�������$��5,0,0,0q�6f   5+      �� 5.      -   5         ��Name$ Comment��5.       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6D   
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Комментарий��6k   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ dateOfScheduledCall��5/   !   $% Назначить звонок��6?   52      �� 53      -   5         ��Name$
 Save��53      $��Сохранить��6'   $��Bottom=�6;   $��Stretch=�6V   $��0q�6t   $
��Auto��6   6�   55      56      58      59      