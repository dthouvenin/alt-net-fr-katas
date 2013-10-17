#include<math.h>
#include<stdio.h>
#include <stdbool.h>
#include<stdlib.h>
unsigned long long l;
unsigned long long n;
unsigned long long max,min;
int * digitsBuffer;

typedef struct Listelt {
unsigned long long val;
struct Listelt * next;
} Listelt;

Listelt * list;
bool next(unsigned long long * i, unsigned long long * j, int * validDigitPos, int * currentMaxDigit, unsigned long long * currentV) {
	if(*j != min) {
		if(*validDigitPos < l) { //okDigit positionned on j
			if((*j)%(int)pow(10,(*validDigitPos+1))==0) {
				//check if validDigitPos incremented :
				if ( (*j / (unsigned long long)pow(10,(*validDigitPos+1)))%10 > *currentMaxDigit + 1 ) {
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
			unsigned long long pos = (*validDigitPos >= l? *validDigitPos-l:0);
			if((*i)%(int)pow(10,(pos+1))==0) {
				if((*i / (unsigned long long)pow(10,(pos+1)))%10 > *currentMaxDigit + 1) {
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
			unsigned long long maxDigit = (*currentV)/(pow(10,(l*2-1)));
			if(maxDigit < *currentMaxDigit) {
				//Value at validDigitPos :
				if(*validDigitPos<l) {
					if(*j/(unsigned long long)pow(10,*validDigitPos)%10 > maxDigit) {
						*validDigitPos = 0;					
					}				
				} else {
					if(*i/(unsigned long long)pow(10,*validDigitPos-l)%10 > maxDigit) {
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
bool checkVampire(unsigned long long i, unsigned long long j) {
	if(i%10==0 && j%10==0 ) {
		return false;	
	}
	int k;
	unsigned long long v = i*j;
	if((v/(int)pow(10,n-1))%10 == 0) {
		return false;	
	}
	unsigned long long ijconcat = i*(int)pow(10,l) + j;
	for(k=0;k<10;k++) {
		digitsBuffer[k] = 0;
	}
	for(k=0;k<n;k++) {
		int digit = (v/(unsigned long long)pow(10,k))%10;
		int ijdigit = (ijconcat/(unsigned long long)pow(10,k))%10;
		
		(digitsBuffer[digit])++;
		(digitsBuffer[ijdigit])--;
	}
	for(k=0;k<10;k++) {
		if(digitsBuffer[k] != 0)
			return false;
	}
	return true;	
}
int vampires(unsigned long long n_) {
	n=n_;
	list = NULL;
	digitsBuffer = malloc(10*sizeof(int));
	if(n%2!=0) return 0;
	l = n/2;
	max = pow(10,l)-1;
	min = pow(10,(l-1));
	unsigned long long currentV=(pow(10,l)-1) * (pow(10,l)-1);
	int currentMaxDigit = currentV/pow(10,(n-1));
	unsigned long long i = max;
	unsigned long long j = max;
	int validDigitPos = 0;
	int numVampires = 0;

	while(next(&i, &j, &validDigitPos, &currentMaxDigit, &currentV)) {
		//printf("%d %d %d %d %d\n",i,j,validDigitPos,currentMaxDigit,i*j);
		// check vampireness :
		if(checkVampire(i,j) == true) {
			unsigned long long v = i*j;
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
			printf("Vampire %llu = %llu * %llu\n",i*j,i,j);
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
