U S E   v e l o c i t y  
 G O  
  
 d r o p   t a b l e   t b l _ m i n _ m a x  
 ;  
  
 / * * * * * *   O b j e c t :     T a b l e   d b o . t b l _ m i n _ m a x         S c r i p t   D a t e :   7 / 2 1 / 2 0 1 8   4 : 1 0 : 3 3   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   d b o . t b l _ m i n _ m a x (  
 	 i d   i n t   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 t r a n s I d   v a r c h a r ( m a x )   N U L L ,  
 	 L E I   v a r c h a r ( m a x )   N U L L ,  
 	 C I F   v a r c h a r ( m a x )   N U L L ,  
 	 b u y S e l l   v a r c h a r ( 4 )   N U L L ,  
 	 e x e c u t i o n D t   d a t e T i m e   N U L L ,  
 	 I S I N   v a r c h a r ( m a x )   N U L L ,  
 	 i n s t r u m e n t   v a r c h a r ( m a x )   N U L L ,  
 	 q u a n t i t y 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 u n i t P r i c e 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 t r a n s a c t i o n C o s t 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 t r a n s a c t i o n F e e s 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 t o t a l C o n s i d e r a t i o n 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 f e e s S c h e d u l e P a r a g r a p h   v a r c h a r ( 5 0 )     N U L L ,  
 	 e f f e c t i v e D t   d a t e T i m e   N U L L ,  
 	 m i n F e e P c t 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 m i n F e e 	 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 m a x F e e P c t 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 m a x F e e 	 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 m i n F l o o r 	 	 	 d e c i m a l ( 1 8 , 2 )   N U L L ,  
 	 c o s t I n d i c a t o r   n v a r c h a r ( 1 0 0 )   N U L L ,  
 	 c o u n t r y   v a r c h a r ( 1 0 0 )   N U L L ,  
 	 b u s i n e s s F e e s I n f o   v a r c h a r ( m a x )   N U L L ,  
 	 f i n a n c i a l A s s e t s T y p e   v a r c h a r ( m a x )   N U L L ,  
 	 M I C   v a r c h a r ( m a x )   N U L L ,  
 	 c c y   v a r c h a r ( 1 0 6 )   N U L L ,  
 	 i s A c t i v e   b i t   n u l l  
 )  
 G O  
 S E T   I D E N T I T Y _ I N S E R T   d b o . t b l _ m i n _ m a x   O N    
  
 U S E   [ v e l o c i t y ]  
 G O  
  
 I N S E R T   I N T O   [ d b o ] . [ t b l _ m i n _ m a x ]  
                       ( i d  
 	 	       , [ t r a n s I d ]  
                       , [ L E I ]  
                       , [ C I F ]  
                       , [ b u y S e l l ]  
                       , [ e x e c u t i o n D t ]  
                       , [ I S I N ]  
                       , [ i n s t r u m e n t ]  
                       , [ q u a n t i t y ]  
                       , [ u n i t P r i c e ]  
                       , [ t r a n s a c t i o n C o s t ]  
                       , [ t r a n s a c t i o n F e e s ]  
                       , [ t o t a l C o n s i d e r a t i o n ]  
                       , [ f e e s S c h e d u l e P a r a g r a p h ]  
                       , [ e f f e c t i v e D t ]  
                       , [ m i n F e e P c t ]  
                       , [ m i n F e e ]  
                       , [ m a x F e e P c t ]  
                       , [ m a x F e e ]  
                       , [ m i n F l o o r ]  
                       , [ c o s t I n d i c a t o r ]  
                       , [ c o u n t r y ]  
                       , [ b u s i n e s s F e e s I n f o ]  
                       , [ f i n a n c i a l A s s e t s T y p e ]  
                       , [ M I C ]  
                       , [ c c y ]  
 	 	       , i s A c t i v e )  
           V A L U E S  
   ( 1 ,   N ' S C T R S C 1 8 1 5 0 0 0 0 0 1 ' ,   N ' R I L F O 7 4 K P 1 C M 8 P 6 P C T 9 6 ' ,   N ' 2 7 1 4 0 0 ' ,   N ' S E L L ' ,   N ' 2 0 1 8 - 0 5 - 1 5   1 3 : 3 9 : 5 3 ' ,   N U L L ,   N ' R O Y A L   D U T C H   S H E L L   P L C ' ,   N ' 2 3 3 1 ' ,   2 5 . 3 5 ,   5 9 0 9 0 . 8 5 0 0 0 0 0 0 0 0 0 6 ,   1 7 4 . 8 8 ,   N ' 5 8 9 1 5 . 9 7 ' ,   N ' G B . 0 2 . 0 0 1 ' ,   N ' 0 1 / 1 3 / 2 0 1 8 ' ,   0 . 2 5 ,   1 4 7 . 7 3 ,   1 ,   5 9 0 . 9 1 ,   C A S T ( 1 5 0 . 0 0   A S   D e c i m a l ( 1 2 ,   2 ) ) ,   N ' w i t h i n   l i m i t ' ,   N ' U n i t e d   K i n g d o m ' ,   N ' T r a d i n g   a n d   I n v e s t m e n t   B u s i n e s s   F e e s ' ,   N ' E q u i t i e s - l i s t e d   a n d   e q u i t y - l i k e   l i s t e d   i n s t r u m e n t   t r a n s a c t i o n s ' ,   N ' S G X - B T   ( S I N G A P O R E   E X C H A N G E   B O N D   T R A D I N G   P T E .   L T D ) ' ,   N ' G B P   ( P o u n d   s t e r l i n g ) ' , 1 )  
   ;  
   G O  
  
  
  
 S E T   I D E N T I T Y _ I N S E R T   d b o . t b l _ m i n _ m a x   O F F  
  
 s e l e c t   *   f r o m   t b l _ m i n _ m a x ;  
 