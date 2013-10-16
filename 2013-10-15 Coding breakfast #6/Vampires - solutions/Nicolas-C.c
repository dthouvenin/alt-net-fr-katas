#include<math.h>
#include<stdio.h>
#include <stdbool.h>
#include<stdlib.h>
int l;
int n;
int max,min;
int * digitsBuffer;

typedef struct Listelt {
int val;
struct Listelt * next;
} Listelt;

Listelt * list;
bool next(int * i, int * j, int * validDigitPos, int * currentMaxDigit, int * currentV) {
	if(*j != min) {
		if(*validDigitPos < l) { //okDigit positionned on j
			if((*j)%(int)pow(10,(*validDigitPos+1))==0) {
				//check if validDigitPos incremented :
				if ( (*j / (int)pow(10,(*validDigitPos+1)))%10 > *currentMaxDigit + 1 ) {
					*j = *j - (10-*currentMaxDigit);
					(*validDigitPos)=0;
				} else {
					(*validDigitPos)++;
					(*j)--;
				}
			} else {
				(*j)--;		
			}
		} else {//okDigit positionned on i
			(*j)--;	
		}
	} else { // *j == min
		if(*i > min) {
			int pos = (*validDigitPos >= l? *validDigitPos-l:0);
			if((*i)%(int)pow(10,(pos+1))==0) {
				if((*i / (int)pow(10,(pos+1)))%10 > *currentMaxDigit + 1) {
					*validDigitPos=0;
				} else {
					(*validDigitPos)++;			
				}
			}
			(*i)--;
			
			if(pos==0 && *i%10 <= *currentMaxDigit) {
				(*validDigitPos) = l;
			//printf(" pos %d %d %d *validDigitPos %d|", pos,(*i)%10,l,*validDigitPos);			
			}
			if(*validDigitPos<l) {
				*j = 10*((*i)/10) + *currentMaxDigit;
				*validDigitPos = 0;		
			} else {
				*j = *i;		
			}
			//update currentV
			*currentV = (*i)*(*j);
			//update currentMaxDigit :
			int maxDigit = (*currentV)/(pow(10,(l*2-1)));
			if(maxDigit < *currentMaxDigit) {
				//Value at validDigitPos :
				if(*validDigitPos<l) {
					if(*j/(int)pow(10,*validDigitPos)%10 > maxDigit) {
						*validDigitPos = 0;					
					}				
				} else {
					if(*i/(int)pow(10,*validDigitPos-l)%10 > maxDigit) {
						*validDigitPos = 0;					
					}
				}
				*currentMaxDigit = maxDigit;		
			}
		} else {
		 return false;		
		}		
	}
	return true;
}
bool checkVampire(int i, int j) {
	if(i%10==0 && j%10==0 ) {
		return false;	
	}
	int k;
	int v = i*j;
	if((v/(int)pow(10,n-1))%10 == 0) {
		return false;	
	}
	int ijconcat = i*(int)pow(10,l) + j;
	for(k=0;k<10;k++) {
		digitsBuffer[k] = 0;
	}
	for(k=0;k<n;k++) {
		int digit = (v/(int)pow(10,k))%10;
		int ijdigit = (ijconcat/(int)pow(10,k))%10;
		
		(digitsBuffer[digit])++;
		(digitsBuffer[ijdigit])--;
	}
	for(k=0;k<10;k++) {
		if(digitsBuffer[k] != 0)
			return false;
	}
	return true;	
}
int vampires(int n_) {
	n=n_;
	list = NULL;
	digitsBuffer = malloc(10*sizeof(int));
	if(n%2!=0) return 0;
	l = n/2;
	max = pow(10,l)-1;
	min = pow(10,(l-1));
	int currentV=(pow(10,l)-1) * (pow(10,l)-1);
	int currentMaxDigit = currentV/pow(10,(n-1));
	int iContainsDigit = -1;
	int i = max;
	int j = max;
	int validDigitPos = 0;
	int validDigitValue = 9;
	int numVampires = 0;

	while(next(&i, &j, &validDigitPos, &currentMaxDigit, &currentV)) {
		//printf("%d %d %d %d %d\n",i,j,validDigitPos,currentMaxDigit,i*j);
		// check vampireness :
		if(checkVampire(i,j) == true) {
			int v = i*j;
			if(list != NULL) {
				Listelt * it = list;
				while(it->next != NULL && it->next->val < v) {
					it = it->next;
				}
				
				if(it->next == NULL || it->next->val != v) {
					Listelt * elt = malloc(sizeof(Listelt));
					elt->val=v;
					elt->next = it->next;
					it->next = elt;
					numVampires++;	
				}
				
			} else {
				list = malloc(sizeof(Listelt));
				list->next = NULL;
				list->val = v;
				numVampires++;			
			}
			printf("Vampire %d = %d * %d\n",i*j,i,j);
		}
		if(currentMaxDigit == 0) break;
	}
	free(digitsBuffer);
	if(list != NULL) {
		Listelt * it = list;
		Listelt * pit;
		while(it->next != NULL) {
			pit = it;
			it = it->next;
			free(pit);
		}
	}
	return numVampires;
}

int main(int argc, char *argv[]) {
	if(argc == 2) {
		printf(" Vampires number : %d\n", vampires(atoi(argv[1])));
	} else {
		printf(" launch with one argument : the number of digit\n");
	}
}
