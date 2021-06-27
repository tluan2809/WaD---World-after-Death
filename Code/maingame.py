import pygame 
import sys 
from globals import * 


def main(): 
    global Width  , Height ,Fps , Fpsclock
    display = pygame.display.set_mode((Width , Height))
    pygame.display.set_caption("WOD")

    while True : 
        for event in pygame.event.get():
            if(event.type == pygame.QUIT):
                pygame.quit()
                sys.exit()
        pygame.display.update()
        Fpsclock.tick(Fps)
    

if __name__ == "__main__":
    main()


