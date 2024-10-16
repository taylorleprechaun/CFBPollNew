# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.
* 10/13/2024: Added strength of schedule to the info I post here

### Rankings (Updated 10/13/2024)

**Week 8 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 6-0 | 0.6081 | 32
2 | Brigham Young | 0.9806 | 6-0 | 0.5763 | 62
3 | Texas | 0.9651 | 6-0 | 0.5470 | 85
4 | Texas Tech | 0.9587 | 5-1 | 0.6778 | 5
5 | Iowa State | 0.9512 | 6-0 | 0.5326 | 94
6 | Kansas State | 0.9365 | 5-1 | 0.6467 | 13
7 | Pittsburgh | 0.9276 | 6-0 | 0.5095 | 108
8 | Miami FL | 0.9259 | 6-0 | 0.4962 | 114
9 | Indiana | 0.9219 | 6-0 | 0.4917 | 115
10 | Washington State | 0.9206 | 5-1 | 0.6503 | 11
11 | Texas A&M | 0.9163 | 5-1 | 0.6121 | 28
12 | Penn State | 0.9116 | 6-0 | 0.4849 | 120
13 | Alabama | 0.9051 | 5-1 | 0.5964 | 43
14 | Missouri | 0.9014 | 5-1 | 0.5901 | 46
15 | Boise State | 0.8900 | 5-1 | 0.6032 | 36
16 | Syracuse | 0.8872 | 5-1 | 0.5810 | 56
17 | SMU | 0.8852 | 5-1 | 0.5676 | 67
18 | Ohio State | 0.8807 | 5-1 | 0.5561 | 80
19 | Georgia | 0.8668 | 5-1 | 0.5516 | 82
20 | Illinois | 0.8609 | 5-1 | 0.5436 | 89
21 | Duke | 0.8594 | 5-1 | 0.5434 | 90
22 | Nebraska | 0.8507 | 5-1 | 0.5230 | 100
23 | Notre Dame | 0.8505 | 5-1 | 0.5456 | 86
24 | James Madison | 0.8500 | 5-1 | 0.5606 | 74
25 | Louisville | 0.8484 | 4-2 | 0.6438 | 15

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2008.md)

#### Observations and Notes (Updated 10/13/2024)

* I decided to include my custom strength of schedule calculation in the info I post here because I've realized how much I talk about it and it might be nice for anyone who looks at this to be able to see what I'm talking about when I do. Last week I mentioned how some 1-loss teams were ranked higher than 0-loss teams because of how good their SoS is. And now you can see that too! Look at Texas Tech and Kansas State with the #5 and #13 ranked SoS. That's the biggest reason they're both in the top 6 ahead of teams like Pittsburgh, Miami FL, and Indiana who all have a SoS in the bottom 20.

#### Predictions (Updated 10/15/2024)

Week 8 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2008.md)

Week 7 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2007.md)

Results:
* Winner: 39 - 13 (75.0%)
* ATS: 30 - 22 (57.7%)
* O/U: 23 - 29 (44.2%)

Season Results:
* Winner: 211 - 97 (68.5%)
* ATS: 145 - 163 (47.1%)
* O/U: 153 - 155 (49.7%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 12/5/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. I found a [site](https://www.thepredictiontracker.com/ncaaresults.php) posted on r/CFB with the results of a bunch of predictive algorithms so I'll definitely use this as some benchmarks when updating my algorithm. As of writing this my outright picks are on the low end, my ATS picks are middle of the pack, and my RMSE is really really bad lol.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me

*New additions for the 2023 season!*

* This year Michigan clocks in with a 42.244 in my poll, placing them at #3 in the Playoff Era
* This year Kent State clocks in with a 15.812 in my poll, placing them at 11th worst in the Playoff Era

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2022 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
