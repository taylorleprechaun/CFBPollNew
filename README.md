# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 1/9/2024)

**Week 17 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Michigan | 1.0000 | 15-0
2 | Washington | 0.9663 | 14-1
3 | Georgia | 0.9595 | 13-1
4 | Alabama | 0.9486 | 12-2
5 | Florida State | 0.9388 | 13-1
6 | Texas | 0.9287 | 12-2
7 | Oregon | 0.9203 | 12-2
8 | Ohio State | 0.9188 | 11-2
9 | Missouri | 0.9148 | 11-2
10 | Mississippi | 0.9085 | 11-2
11 | Penn State | 0.8859 | 10-3
12 | Louisiana State | 0.8830 | 10-3
13 | Oklahoma | 0.8590 | 10-3
14 | Liberty | 0.8541 | 13-1
15 | James Madison | 0.8365 | 11-2
16 | Arizona | 0.8362 | 10-3
17 | Notre Dame | 0.8357 | 10-3
18 | Kansas State | 0.8348 | 9-4
19 | Tennessee | 0.8179 | 9-4
20 | Louisville | 0.8178 | 10-4
21 | Clemson | 0.8155 | 9-4
22 | Troy | 0.8118 | 11-3
23 | Oklahoma State | 0.8101 | 10-4
24 | Memphis | 0.8078 | 10-3
25 | Tulane | 0.8065 | 11-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2017%20NCG.md)

#### Observations and Notes (Updated 1/9/2024)

* Another season in the wraps has given me a number of things I want to update in both the rating and prediction algorithms. I have some good ideas for both I'm excited to try out (if I can ever get a good chunk of free time to mess with)

#### Predictions (Updated 1/9/2024)

National Championship Result: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2016%20NCG.md):
* Winner: 1 - 0 (100.0%)
* ATS: 1 - 0 (100.0%)
* O/U: 1 - 0 (100.0%)

Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

Retrospective:
* Two seasons in the books on my predictions algorithm running for the full season. In between the 2022 and 2023 seasons I made some very very very minor changes to the algorithm but nothing that I would expect to produce meaningful differences in the results. I've identified a number of changes I want to make in it which I hope to get done before next season
* What went well?
    * It's automated now (except for the bowl games for some reason) which is fantastic.
    * Not something that can be seen but the code that runs this is just so much easier to understand than it used to be. The way it was written before was really weird and impossible to understand without some of the giant summary blocks in the code (which is excluded from this repo) and now it's actually super straight forward.
* What didn't go well?
    * Even though on the surface the results look fine (68% picks, 49% spread and o/u) the way the results look up close is way off. The score predictions are usually way off the mark giving huge error margins compared to actual results. This is something I have plans to address.
* Takeaways
    * A heck of a lot man.

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
